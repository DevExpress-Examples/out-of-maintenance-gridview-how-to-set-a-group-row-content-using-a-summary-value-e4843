@Html.DevExpress().GridView(
    Sub(settings)
            settings.Name = "gridView"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

            settings.KeyFieldName = "ID"
            settings.Columns.Add("ID")
            settings.Columns.Add(Sub(c)
                                         c.FieldName = "Group"
                                         c.GroupIndex = 0
                                 End Sub)

            settings.SetGroupRowContentTemplateContent(
                Sub(c)
                                            Dim grid = c.Grid
                                            Dim summary = grid.GroupSummary("ID")
                                            Dim sumValue = grid.GetGroupSummaryValue(c.VisibleIndex, summary)
                                            ViewContext.Writer.Write(c.GroupText & " Summary value: " & sumValue)
                                    End Sub)

            settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "ID")

            settings.PreRender = Sub(s, e)
                                         Dim grid As MVCxGridView = TryCast(s, MVCxGridView)
                                         grid.ExpandAll()
                                 End Sub
    End Sub).Bind(Model).GetHtml()