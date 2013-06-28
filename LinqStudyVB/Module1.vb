Module Module1

    Sub Main()
        Console.WriteLine("(VB)Problem1:" + CStr(Problem1(1000)))
        Console.WriteLine("(VB)Problem2:" + CStr(Problem2(4000000)))
    End Sub

    '' http://odz.sakura.ne.jp/projecteuler/index.php?cmd=read&page=Problem%201
    ''' <summary>
    ''' 10未満の自然数のうち, 3 もしくは 5 の倍数になっているものは 3, 5, 6, 9 の4つがあり, これらの合計は 23 になる.
    ''' 同じようにして, 1000 未満の 3 か 5 の倍数になっている数字の合計を求めよ.
    ''' </summary>
    ''' <param name="limit">制限値</param>
    ''' <returns>答え</returns>
    ''' <remarks></remarks>
    Public Function Problem1(ByVal limit As Integer) As Integer
        Dim sum As Integer = 0
        For i = 0 To limit - 1
            If i Mod 3 = 0 OrElse i Mod 5 = 0 Then
                sum += i
            End If
        Next
        Return sum
    End Function

    '' http://odz.sakura.ne.jp/projecteuler/index.php?cmd=read&page=Problem%202
    ''' <summary>
    ''' フィボナッチ数列の項は前の2つの項の和である. 最初の2項を 1, 2 とすれば, 最初の10項は以下の通りである.
    ''' 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    ''' 数列の項の値が400万を超えない範囲で, 偶数値の項の総和を求めよ.
    ''' </summary>
    ''' <param name="limit">制限値</param>
    ''' <returns>答え</returns>
    ''' <remarks></remarks>
    Public Function Problem2(ByVal limit As Integer)
        Dim sum = 0
        Dim a = 1
        Dim b = 1
        While b < limit
            If b Mod 2 = 0 Then
                sum += b
            End If
            Dim temp = a
            a = b
            b = a + temp
        End While
        Return sum
    End Function

End Module
