Imports System.Text
Imports System.Windows.Threading
Imports MahApps.Metro.Controls.Dialogs
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports OxyPlot
Imports OxyPlot.Axes
Imports OxyPlot.Series

Class MainWindow
    Dim seprator As New List(Of Decimal)
    Dim stoped As Boolean = False
    Dim progrssval As Decimal
    Dim model1 As PlotModel
    Dim model2 As PlotModel
    Dim model3 As PlotModel
    Dim model4 As PlotModel
    Dim model5 As PlotModel
    Dim model6 As PlotModel
    Dim model7 As PlotModel
    Dim pdfExporter = New PdfExporter With {.Width = 1920, .Height = 1080}
    Dim list1 As New List(Of Decimal)
    Dim list2 As New List(Of Decimal)
    Dim list3 As New List(Of Decimal)
    Private Shared Function Clean_Lines(ByVal Raw As String) As String
        Dim n = GetLineNumber("DOY", Raw)
        Dim lines As String() = Raw.Split(IIf(Raw.Contains(vbCrLf), vbCrLf, vbLf))
        Dim output As New StringBuilder
        For i = n To lines.Count - 1
            If Not lines(i).Trim() <> String.Empty > 0 Then output.Append(lines(i) & vbCrLf)
        Next
        Return output.ToString
    End Function
    Public Shared Function GetLineNumber(ByVal text As String, ByVal lineToFind As String, ByVal Optional comparison As StringComparison = StringComparison.CurrentCulture) As Integer
        Dim lines As String() = lineToFind.Split(vbLf)
        Dim ans As Integer
        Parallel.For(0, lines.Count, Sub(i As Integer)
                                         If lines(i).Contains(text) Then
                                             ans = i + 1
                                         End If
                                     End Sub)
        Return ans
    End Function
    Private Sub MetroWindow_ContentRendered(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim FolderPicker As New CommonOpenFileDialog
        FolderPicker.IsFolderPicker = True
        If FolderPicker.ShowDialog() = CommonFileDialogResult.Ok Then
            textbox1.Text = FolderPicker.FileName
        End If

    End Sub
    Private Sub update_progress()
        Dim trigger As Boolean = False
main:
        Dispatcher.Invoke(Sub()
                              If progress.Value <> progress.Maximum Then
                                  progress.Value = progrssval
                              Else
                                  trigger = True
                              End If
                          End Sub)
        If trigger Then
            Exit Sub
        Else
            System.Threading.Thread.Sleep(100)
            GoTo main
        End If
    End Sub
    Private Sub Do_Work()

        progrssval = 0
            stoped = False
            Dispatcher.InvokeAsync(Sub()
                                       status.Text = "Creating Models..."
                                       progress.Visibility = Visibility.Visible
                                       progress.Value = 0
                                   End Sub)
            model1 = New PlotModel With {.PlotType = PlotType.Cartesian, .Background = OxyColors.GhostWhite, .Title = "X axis"}
            model2 = New PlotModel With {.PlotType = PlotType.Cartesian, .Background = OxyColors.GhostWhite, .Title = "Y axis"}
            model3 = New PlotModel With {.PlotType = PlotType.Cartesian, .Background = OxyColors.GhostWhite, .Title = "Z axis"}
            model4 = New PlotModel With {.PlotType = PlotType.Cartesian, .Background = OxyColors.GhostWhite, .Title = "All in One X"}
            '  model5 = New PlotModel With {.PlotType = PlotType.Cartesian, .Background = OxyColors.GhostWhite, .Title = "Single Mean X"}
            model5 = New PlotModel With {.PlotType = PlotType.Cartesian}
            model6 = New PlotModel With {.PlotType = PlotType.Cartesian, .Background = OxyColors.GhostWhite, .Title = "Repeated Mean X"}
            model7 = New PlotModel With {.PlotType = PlotType.Cartesian, .Background = OxyColors.GhostWhite, .Title = "Reduced X"}




            model1.Series.Add(New LineSeries())
            model2.Series.Add(New LineSeries())
            model3.Series.Add(New LineSeries())
            model5.Series.Add(New LineSeries())
            model6.Series.Add(New LineSeries())
            model7.Series.Add(New LineSeries())

            model4.Series.Clear()
            list1.Clear()
            list2.Clear()
            list3.Clear()
            seprator.Clear()
            Dispatcher.InvokeAsync(Sub()
                                       status.Text = "Reading Files..."
                                   End Sub)
            Dim files() As String = Nothing
            Dispatcher.Invoke(Sub()
                                  files = IO.Directory.GetFiles(textbox1.Text)
                                  status.Text = "Processing Input, Please Wait..."
                              End Sub)
            For j = 0 To files.Count - 1
                Dim buffer_text As String = Clean_Lines(IO.File.ReadAllText(files(j)))
                Dim lines As String() = buffer_text.Split(IIf(buffer_text.Contains(vbCrLf), vbCrLf, vbLf))
                For i = 0 To lines.Count - 1
                    If Not String.IsNullOrEmpty(lines(i)) Then
                        Dim buffer_string As String() = lines(i).Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
                        If buffer_string.Count = 7 Then
                        If buffer_string(3) <> 99999 Then list1.Add(buffer_string(3))
                        If buffer_string(4) <> 99999 Then list2.Add(buffer_string(4))
                        If buffer_string(5) <> 99999 Then list3.Add(buffer_string(5))
                    End If
                    End If
                Next
                seprator.Add(list1.Count)
            Next
            For i = 0 To seprator.Count - 1
                model4.Series.Add(New LineSeries())
            Next
            model1.Axes.Clear()
            model2.Axes.Clear()
            model3.Axes.Clear()
            model4.Axes.Clear()
            model5.Axes.Clear()
            model6.Axes.Clear()
            model7.Axes.Clear()
            model1.Axes.Add(New LinearAxis() With {.AbsoluteMaximum = list1.Max + 5, .AbsoluteMinimum = list1.Min - 5, .Position = AxisPosition.Left})
            model2.Axes.Add(New LinearAxis() With {.AbsoluteMaximum = list2.Max + 5, .AbsoluteMinimum = list2.Min - 5, .Position = AxisPosition.Left})
            model3.Axes.Add(New LinearAxis() With {.AbsoluteMaximum = list3.Max + 5, .AbsoluteMinimum = list3.Min - 5, .Position = AxisPosition.Left})
            model4.Axes.Add(New LinearAxis() With {.AbsoluteMaximum = list1.Max + 5, .AbsoluteMinimum = list1.Min - 5, .Position = AxisPosition.Left})
            model5.Axes.Add(New LinearAxis() With {.Position = AxisPosition.Left})
            model6.Axes.Add(New LinearAxis() With {.Position = AxisPosition.Left})
            model7.Axes.Add(New LinearAxis() With {.Position = AxisPosition.Left})

            '----------------------
            model1.Axes.Add(New LinearAxis() With {.Position = AxisPosition.Bottom, .MinorStep = 1440, .MajorStep = 1440 * 50, .LabelFormatter = AddressOf Formatter})
            model2.Axes.Add(New LinearAxis() With {.Position = AxisPosition.Bottom, .MinorStep = 1440, .MajorStep = 1440 * 50, .LabelFormatter = AddressOf Formatter})
            model3.Axes.Add(New LinearAxis() With {.Position = AxisPosition.Bottom, .MinorStep = 1440, .MajorStep = 1440 * 50, .LabelFormatter = AddressOf Formatter})
            model4.Axes.Add(New LinearAxis() With {.Position = AxisPosition.Bottom, .MinorStep = 60, .MajorStep = 60 * 5, .LabelFormatter = AddressOf Formatter2})
            model5.Axes.Add(New LinearAxis() With {.Position = AxisPosition.Bottom})
            model6.Axes.Add(New LinearAxis() With {.Position = AxisPosition.Bottom, .MinorStep = 1440, .MajorStep = 1440 * 50})
            model7.Axes.Add(New LinearAxis() With {.Position = AxisPosition.Bottom, .MinorStep = 1440, .MajorStep = 1440 * 50})

            Dispatcher.InvokeAsync(Sub()
                                       progress.Maximum = list1.Count * 4 + list2.Count + list3.Count
                                       status.Text = "Processing Plot Data..."
                                   End Sub)
            Dim model1typed As LineSeries = CType(model1.Series(0), LineSeries)
            Dim model2typed As LineSeries = CType(model2.Series(0), LineSeries)
            Dim model3typed As LineSeries = CType(model3.Series(0), LineSeries)
            Task.Factory.StartNew(AddressOf Progress_update)
            Task.Factory.StartNew(Sub()
                                      For i = 0 To list1.Count - 1
                                          model1typed.Points.Add(New DataPoint(i, list1(i)))
                                          progrssval += 1
                                      Next
                                      For j = 0 To list2.Count - 1
                                          model2typed.Points.Add(New DataPoint(j, list2(j)))
                                          progrssval += 1
                                      Next
                                      For k = 0 To list3.Count - 1
                                          model3typed.Points.Add(New DataPoint(k, list3(k)))
                                          progrssval += 1
                                      Next
                                      Dim holder As Double = 0
                                      Dim counter As Double = 0
                                      While seprator.Count <> 0
                                          For i = holder To seprator(0) - 1
                                              CType(model4.Series(counter), LineSeries).Points.Add(New DataPoint(i - holder, list1(i)))
                                          Next
                                          counter = counter + 1
                                          holder = seprator(0)
                                          seprator.RemoveAt(0)
                                          progrssval = progrssval + 1
                                      End While
                                      Dim n As New List(Of Double)
                                      Dim m As New List(Of Double)
                                      For i = 0 To model4.Series.Count - 1
                                          If CType(model4.Series(i), LineSeries).Points.Count > 1000 Then
                                              n.Add(CType(model4.Series(i), LineSeries).Points.Count)
                                          End If
                                      Next
                                      For i = 0 To m.Count - 1
                                          model4.Series.RemoveAt(m(i))
                                      Next
                                      Dim buffer As Double
                                      Dim xxxxxx = n.Min
                                      Dim buffer_list2 As New List(Of Double)
                                      For i = 0 To n.Min - 1
                                          buffer = 0
                                          For j = 0 To model4.Series.Count - 1
                                              If CType(model4.Series(j), LineSeries).Points.Count > 1000 Then buffer += CType(model4.Series(j), LineSeries).Points(i).Y
                                          Next
                                          CType(model5.Series(0), LineSeries).Points.Add(New DataPoint(i, buffer / model4.Series.Count))
                                          buffer_list2.Add(buffer / model4.Series.Count)
                                      Next
                                      model5.Axes(0).AbsoluteMaximum = buffer_list2.Max + 0.5
                                      model5.Axes(0).AbsoluteMinimum = buffer_list2.Min - 0.5
                                      model6.Axes(0).AbsoluteMaximum = buffer_list2.Max + 0.5
                                      model6.Axes(0).AbsoluteMinimum = buffer_list2.Min - 0.5
                                      Dim counter2 As Double = 0
                                      For i = 0 To list1.Count - 1
                                          If counter2 = xxxxxx - 1 Then
                                              counter2 = 0
                                          End If
                                          CType(model6.Series(0), LineSeries).Points.Add(New DataPoint(i, CType(model5.Series(0), LineSeries).Points(counter2).Y))
                                          counter2 += 1
                                      Next

                                      Dim buffer_list As New List(Of Double)
                                      For i = 0 To list1.Count - 1
                                          CType(model7.Series(0), LineSeries).Points.Add(New DataPoint(i, list1(i) - CType(model6.Series(0), LineSeries).Points(i).Y))
                                          buffer_list.Add(list1(i) - CType(model6.Series(0), LineSeries).Points(i).Y)
                                          progrssval += 1
                                      Next
                                      model7.Axes(0).AbsoluteMaximum = buffer_list.Max + 1
                                      model7.Axes(0).AbsoluteMinimum = buffer_list.Min - 1
                                      stoped = True
                                      Dispatcher.InvokeAsync(Sub()
                                                                 minmax1.Text = "Max-min=" & Math.Abs(list1.Max - list1.Min)
                                                                 minmax2.Text = "Max-min=" & Math.Abs(list2.Max - list2.Min)
                                                                 minmax3.Text = "Max-min=" & Math.Abs(list3.Max - list3.Min)
                                                                 plot1.Model = model1
                                                                 plot2.Model = model2
                                                                 plot3.Model = model3
                                                                 plot4.Model = model4
                                                                 plot5.Model = model5
                                                                 plot6.Model = model6
                                                                 plot7.Model = model7
                                                                 status.Text = "Ready"
                                                                 progress.Visibility = Visibility.Hidden
                                                                 tabs.IsEnabled = True
                                                             End Sub)
                                  End Sub)

    End Sub
    Private Sub Progress_update()
        While Not stoped
            Dispatcher.Invoke(Sub()
                                  progress.Value = progrssval
                              End Sub)
            System.Threading.Thread.Sleep(1)
        End While

    End Sub
    Public Function Formatter(ByVal Val As Double) As String
        Return Val / 1440
    End Function
    Public Function Formatter2(ByVal val As Double) As String
        Return Math.Ceiling((val / 1440) * 24)
    End Function

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        If textbox1.Text <> "" Then
            Task.Factory.StartNew(AddressOf Do_Work, TaskCreationOptions.LongRunning)
        Else
            ShowMessageAsync("No Folder", "Please select a folder first!")
        End If

    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        Dim FolderPicker As New CommonSaveFileDialog
        FolderPicker.Filters.Add(New CommonFileDialogFilter("PDF File", ".pdf"))
        If FolderPicker.ShowDialog = CommonFileDialogResult.Ok Then
            pdfExporter.Export(model1, IO.File.Create(FolderPicker.FileName & ".pdf"))
        End If
    End Sub

    Private Sub save2_Click(sender As Object, e As RoutedEventArgs) Handles save2.Click
        Dim FolderPicker As New CommonSaveFileDialog
        FolderPicker.Filters.Add(New CommonFileDialogFilter("PDF File", ".pdf"))
        If FolderPicker.ShowDialog = CommonFileDialogResult.Ok Then
            pdfExporter.Export(model2, IO.File.Create(FolderPicker.FileName & ".pdf"))
        End If
    End Sub

    Private Sub save3_Click(sender As Object, e As RoutedEventArgs) Handles save3.Click
        Dim FolderPicker As New CommonSaveFileDialog
        FolderPicker.Filters.Add(New CommonFileDialogFilter("PDF File", ".pdf"))
        If FolderPicker.ShowDialog = CommonFileDialogResult.Ok Then
            pdfExporter.Export(model3, IO.File.Create(FolderPicker.FileName & ".pdf"))
        End If
    End Sub

    Private Sub Button_Click_3(sender As Object, e As RoutedEventArgs)
        Dim FolderPicker As New CommonSaveFileDialog
        FolderPicker.Filters.Add(New CommonFileDialogFilter("PDF File", ".pdf"))
        If FolderPicker.ShowDialog = CommonFileDialogResult.Ok Then
            pdfExporter.Export(model4, IO.File.Create(FolderPicker.FileName & ".pdf"))
        End If
    End Sub

    Private Sub save4_Click(sender As Object, e As RoutedEventArgs) Handles save4.Click
        Dim FolderPicker As New CommonSaveFileDialog
        FolderPicker.Filters.Add(New CommonFileDialogFilter("PDF File", ".pdf"))
        If FolderPicker.ShowDialog = CommonFileDialogResult.Ok Then
            pdfExporter.Export(model5, IO.File.Create(FolderPicker.FileName & ".pdf"))
        End If
    End Sub

    Private Sub save5_Click(sender As Object, e As RoutedEventArgs) Handles save5.Click
        Dim FolderPicker As New CommonSaveFileDialog
        FolderPicker.Filters.Add(New CommonFileDialogFilter("PDF File", ".pdf"))
        If FolderPicker.ShowDialog = CommonFileDialogResult.Ok Then
            pdfExporter.Export(model6, IO.File.Create(FolderPicker.FileName & ".pdf"))
        End If
    End Sub
End Class
