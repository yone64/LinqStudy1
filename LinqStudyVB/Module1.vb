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
        Return GetNaturalNumber().
            TakeWhile(Function(x) x < limit).
            Where(Function(y) y Mod 3 = 0 OrElse y Mod 5 = 0).
            Sum()
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
        Return GetFibonacchi().
            TakeWhile(Function(x) x < limit).
            Where(Function(y) y Mod 2 = 0).
            Sum()
    End Function

    ''' <summary>
    ''' 自然数を返すメソッド
    ''' </summary>
    ''' <returns>列挙可能な自然数</returns>
    ''' <remarks></remarks>
    Public Iterator Function GetNaturalNumber() As IEnumerable(Of Integer)
        Dim i As Integer = 0
        While True
            i = i + 1
            Yield i
        End While
    End Function

    ''' <summary>
    ''' フィボナッチ数列を返すメソッド
    ''' </summary>
    ''' <returns>列挙可能なフィボナッチ数列</returns>
    ''' <remarks></remarks>
    Public Iterator Function GetFibonacchi() As IEnumerable(Of Integer)
        Dim a = 1
        Dim b = 1
        While True
            Yield b
            Dim temp = a
            a = b
            b += temp
        End While
    End Function

    ''' <summary>
    ''' 終了条件を設定するメソッド
    ''' </summary>
    ''' <param name="source">元数列</param>
    ''' <param name="predicate">終了条件</param>
    ''' <returns>終了条件が設定された数列</returns>
    ''' <remarks></remarks>
    <Runtime.CompilerServices.Extension()> _
    Public Iterator Function TakeWhile(source As IEnumerable(Of Integer), predicate As Func(Of Integer, Boolean)) As IEnumerable(Of Integer)
        For Each i In source
            If predicate(i) Then
                Yield i
            Else
                Exit For
            End If
        Next
    End Function

    ''' <summary>
    ''' 抽出条件を設定するメソッド
    ''' </summary>
    ''' <param name="source">元数列</param>
    ''' <param name="predicate">抽出条件</param>
    ''' <returns>抽出条件が設定された数列</returns>
    ''' <remarks></remarks>
    <Runtime.CompilerServices.Extension()> _
    Public Iterator Function Where(source As IEnumerable(Of Integer), predicate As Func(Of Integer, Boolean)) As IEnumerable(Of Integer)
        For Each i In source
            If predicate(i) Then
                Yield i
            End If
        Next
    End Function

    ''' <summary>
    ''' 合計を求めるメソッド
    ''' </summary>
    ''' <param name="source">元数列</param>
    ''' <returns>合計</returns>
    ''' <remarks></remarks>
    <Runtime.CompilerServices.Extension()> _
    Public Function Sum(source As IEnumerable(Of Integer)) As Integer
        Dim sum_ As Integer = 0
        For Each i In source
            sum_ += i
        Next
        Return sum_
    End Function
End Module
