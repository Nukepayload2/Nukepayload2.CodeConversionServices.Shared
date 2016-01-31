Option Strict Off
Imports System.Runtime
Imports System.Runtime.InteropServices.Marshal
Imports System.Runtime.InteropServices

''' <summary>
''' 为不支持指针类型的语言提供指针支持。
''' </summary>
''' <typeparam name="T"></typeparam>
''' <remarks></remarks>
<Security.SecurityCritical()>
Friend Structure Pointer(Of T As Structure)
    ''' <summary>
    ''' 目标地址值
    ''' </summary>
    Public Address As IntPtr
    ''' <summary>
    ''' 目标元素的大小
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ObjectSize As Integer
    Private Const ErrorTextCannotRead = "Void指针不支持此操作，请把ObjSize设置为大于0的值。"
    '''<summary> 读写目标内存 *p</summary>
    Public Property Target As T
        Get
            Return TargetElement(0)
        End Get
        Set(Value As T)
            TargetElement(0) = Value
        End Set
    End Property
    '''<summary> 自增指针后读写目标内存 *++p </summary>
    Public Property IncrementTarget As T
        Get
            Increment()
            Return TargetElement(0)
        End Get
        Set(Value As T)
            Increment()
            TargetElement(0) = Value
        End Set
    End Property
    '''<summary> 读写目标内存后自增指针 *p++ </summary>
    Public Property TargetIncrement As T
        Get
            Dim r = TargetElement(0)
            Increment()
            Return r
        End Get
        Set(Value As T)
            TargetElement(0) = Value
            Increment()
        End Set
    End Property
    '''<summary> 自减指针后读写目标内存 *--p </summary>
    Public Property DecrementTarget As T
        Get
            Decrement()
            Return TargetElement(0)
        End Get
        Set(Value As T)
            Decrement()
            TargetElement(0) = Value
        End Set
    End Property
    '''<summary> 读写目标内存后自减指针 *p-- </summary>
    Public Property TargetDecrement As T
        Get
            Dim r = TargetElement(0)
            Decrement()
            Return r
        End Get
        Set(Value As T)
            TargetElement(0) = Value
            Decrement()
        End Set
    End Property
    ''' <summary>获取或设置指向的目标(注意!如果要紧凑地序列化和反序列化结构体,则结构体应带有以下特性:&lt;System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack:=1)&gt;)</summary>
    Default Public Property TargetElement(index As Integer) As T
        Set(s As T)
            If ObjectSize = 0 Then Throw New InvalidOperationException(ErrorTextCannotRead)
            StructureToPtr(s, Address + index * ObjectSize, False)
        End Set
        Get
            If ObjectSize = 0 Then Throw New InvalidOperationException(ErrorTextCannotRead)
            Return PtrToStructure(Of T)(Address + ObjectSize * index)
        End Get
    End Property
    ''' <summary>
    ''' 转换为IntPtr
    ''' </summary>
    ''' <param name="p">Pointer</param>
    Public Shared Narrowing Operator CType(p As Pointer(Of T)) As IntPtr
        Return p.Address
    End Operator
    ''' <summary>
    ''' IntPtr转换为Pointer(Of T)
    ''' </summary>
    ''' <param name="p">Pointer</param>
    Public Shared Widening Operator CType(p As IntPtr) As Pointer(Of T)
        Return New Pointer(Of T)(p)
    End Operator
    ''' <summary>
    ''' 数组首地址转换为Pointer(Of T)
    ''' </summary>
    ''' <param name="Arr">数组</param>
    Public Shared Narrowing Operator CType(Arr As Array) As Pointer(Of T)
        Return New Pointer(Of T)(Arr)
    End Operator
    ''' <summary>c样式的指针加法(+=)，会自动计算元素的大小</summary>
    Public Sub Add(Value As Integer)
        Address += Value * If(ObjectSize = 0, 1, ObjectSize)
    End Sub
    ''' <summary>把指针当作一般的数字增加，不会自动计算元素的大小。用于模拟Void*。</summary>
    Public Sub AddPosition(Value As Integer)
        Address += Value
    End Sub
    ''' <summary>c样式的指针自增(++)，会自动计算元素的大小</summary>
    Public Sub Increment()
        Address += 1
    End Sub
    ''' <summary>c样式的指针自减(--)，会自动计算元素的大小</summary>
    Public Sub Decrement()
        Address -= 1
    End Sub
    ''' <summary>c样式的指针减法(-=)，会自动计算元素的大小</summary>
    Public Sub Minus(Value As Integer)
        Address -= Value * If(ObjectSize = 0, 1, ObjectSize)
    End Sub
    ''' <summary>把指针当作一般的数字减少，不会自动计算元素的大小。用于模拟<code>System.Void*</code>。</summary>
    Public Sub MinusPosition(Value As Integer)
        Address -= Value
    End Sub
    ''' <summary>c样式的指针加法，会自动计算元素的大小</summary>
    Public Shared Operator +(a As Pointer(Of T), b As Integer) As Pointer(Of T)
        a.Address += b * If(a.ObjectSize = 0, 1, a.ObjectSize)
        Return a
    End Operator

    ''' <summary>c样式的指针减法，会自动计算元素的大小</summary>
    Public Shared Operator -(a As Pointer(Of T), b As Integer) As Pointer(Of T)
        a.Address -= b * If(a.ObjectSize = 0, 1, a.ObjectSize)
        Return a
    End Operator
    Private Sub AddrInit()
        _ObjectSize = SizeOf(Of T)()
    End Sub

    '''<summary>从数组获取指针</summary>
    Sub New(arr As T())
        Address = UnsafeAddrOfPinnedArrayElement(arr, 0)
        AddrInit()
    End Sub
    ''' <summary>将IntPtr包装进去</summary>
    Sub New(Ptr As IntPtr)
        Address = Ptr
        AddrInit()
    End Sub
    ''' <summary>
    ''' 转换指针类型
    ''' </summary>
    ''' <typeparam name="NewPtr">新的指针类型</typeparam>
    Public Function Cast(Of NewPtr As Structure)() As Pointer(Of NewPtr)
        Return New Pointer(Of NewPtr)(Address)
    End Function

End Structure