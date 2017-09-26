
Public Class Sound

    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer

    Private _name As String = Nothing
    Public Property Name As String
        Set(value As String)
            _name = value
        End Set
        Get
            Return _name
        End Get
    End Property

    Public Sub Play(ByVal id As Integer, ByVal repeat As Boolean, Optional volume As Integer = 1000)
        mciSendString("Open " & GetFile(id) & " alias " & _name, CStr(0), 0, 0)
        If repeat = True Then
            mciSendString("play " & _name & " repeat", CStr(0), 0, 0)
        Else
            mciSendString("play " & _name, CStr(0), 0, 0)
        End If
        'Optionally set volume
        mciSendString("setaudio " & _name & " volume to " & volume, CStr(0), 0, 0)
    End Sub

    Public Sub Kill(ByVal song As String)
        mciSendString("close " & song, CStr(0), 0, 0)
        _name = Nothing
    End Sub

    'Media library
    Private Function GetFile(ByVal id As Integer) As String
        Dim path As String = ""

        'Spaces cause failure to load (Add quotes)
        'Dots in path can cause failure to load
        'very long paths will cause failure to load (255 max?)

        Select Case id
            Case 0
                path = Form1.resourcePath + "Sound\foghorn.mp3"
            Case 1
                path = Form1.resourcePath + "Sound\marbles.mp3"
            Case 2
                path = Form1.resourcePath + "Sound\seagulls.mp3"
            Case 3
                path = Form1.resourcePath + "Sound\sawing.mp3"
        End Select

        Return Chr(34) + path + Chr(34)
    End Function

End Class
