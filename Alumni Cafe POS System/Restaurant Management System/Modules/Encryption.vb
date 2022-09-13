Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography
Public Class Encryption
    Public Shared Function InverseByBase(st As String, MoveBase As Integer) As String
        Dim SB As New StringBuilder()
        'st = ConvertToLetterDigit(st);
        Dim c As Integer
        Dim i As Integer = 0
        While i < st.Length
            If i + MoveBase > st.Length - 1 Then
                c = st.Length - i
            Else
                c = MoveBase
            End If
            SB.Append(InverseString(st.Substring(i, c)))
            i += MoveBase
        End While
        Return SB.ToString()
    End Function

    Public Shared Function InverseString(st As String) As String
        Dim SB As New StringBuilder()
        For i As Integer = st.Length - 1 To 0 Step -1
            SB.Append(st(i))
        Next
        Return SB.ToString()
    End Function

    Public Shared Function ConvertToLetterDigit(st As String) As String
        Dim SB As New StringBuilder()
        For Each ch As Char In st
            If Char.IsLetterOrDigit(ch) = False Then
                SB.Append(Convert.ToInt16(ch).ToString())
            Else
                SB.Append(ch)
            End If
        Next
        Return SB.ToString()
    End Function

    ''' <summary>
    ''' moving all characters in string insert then into new index
    ''' </summary>
    ''' <param name="st">string to moving characters</param>
    ''' <returns>moved characters string</returns>
    Public Shared Function Boring(st As String) As String
        Dim NewPlace As Integer
        Dim ch As Char
        For i As Integer = 0 To st.Length - 1
            NewPlace = i * Convert.ToUInt16(st(i))
            NewPlace = NewPlace Mod st.Length
            ch = st(i)
            st = st.Remove(i, 1)
            st = st.Insert(NewPlace, ch.ToString())
        Next
        Return st
    End Function

    Public Shared Function MakePassword(st As String, Identifier As String) As String
        If Identifier.Length <> 3 Then
            Throw New ArgumentException("Identifier must be 3 character length")
        End If

        Dim num As Integer() = New Integer(2) {}
        num(0) = Convert.ToInt32(Identifier(0).ToString(), 10)
        num(1) = Convert.ToInt32(Identifier(1).ToString(), 10)
        num(2) = Convert.ToInt32(Identifier(2).ToString(), 10)
        st = Boring(st)
        st = InverseByBase(st, num(0))
        st = InverseByBase(st, num(1))
        st = InverseByBase(st, num(2))

        Dim SB As New StringBuilder()
        For Each ch As Char In st
            SB.Append(ChangeChar(ch, num))
        Next
        Return SB.ToString()
    End Function

    Private Shared Function ChangeChar(ch As Char, EnCode As Integer()) As Char
        ch = Char.ToUpper(ch)
        If ch >= "A"c AndAlso ch <= "H"c Then
            Return Convert.ToChar(Convert.ToInt16(ch) + 2 * EnCode(0))
        ElseIf ch >= "I"c AndAlso ch <= "P"c Then
            Return Convert.ToChar(Convert.ToInt16(ch) - EnCode(2))
        ElseIf ch >= "Q"c AndAlso ch <= "Z"c Then
            Return Convert.ToChar(Convert.ToInt16(ch) - EnCode(1))
        ElseIf ch >= "0"c AndAlso ch <= "4"c Then
            Return Convert.ToChar(Convert.ToInt16(ch) + 5)
        ElseIf ch >= "5"c AndAlso ch <= "9"c Then
            Return Convert.ToChar(Convert.ToInt16(ch) - 5)
        Else
            Return "0"c
        End If
    End Function
End Class
