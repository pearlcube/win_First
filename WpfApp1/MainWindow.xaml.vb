Imports System.Text
Imports System.IO
Imports Newtonsoft.Json

Class MainWindow

    Private Sub Button1_Click(sender As Object, e As RoutedEventArgs)
        'If text1.Text = "CHANGE" Then
        '    text1.Text = "HELLO"
        'Else
        '    text1.Text = "CHANGE"
        'End If

        Dim data1 = New SampleData With
        {
          .Description = "サンプル",
          .UpdateDate = DateTimeOffset.Now,
          .Data = New Dictionary(Of Integer, String) From
          {
            {1, "データ1"}, {2, "データ2"}
          }
        }

        Dim output As String = JsonConvert.SerializeObject(data1)
        Dim deserialized = JsonConvert.DeserializeObject(Of SampleData)(output)

        Dim sjisEnc As Encoding = Encoding.GetEncoding("Unicode")
        Dim writer As StreamWriter = New StreamWriter("Test.txt", True, sjisEnc)
        writer.WriteLine(output)
        writer.Close()

    End Sub


End Class

Public Class SampleData
    Public Property Description As String
    Public Property UpdateDate As DateTimeOffset
    Public Property Data As Dictionary(Of Integer, String)
End Class


