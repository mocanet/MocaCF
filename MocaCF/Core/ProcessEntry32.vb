
Imports System.Text
Imports System.Runtime.InteropServices

Public Class ProcessEntry32

    Private Const INVALID_HANDLE_VALUE As Integer = -1



    Private Const _sizeOffset As Integer = 0

    Private Const _usageOffset As Integer = 4

    Private Const _processIDOffset As Integer = 8

    Private Const _defaultHeapIDOffset As Integer = 12

    Private Const _moduleIDOffset As Integer = 16

    Private Const _threadsOffset As Integer = 20

    Private Const _parentProcessIDOffset As Integer = 24

    Private Const _priClassBaseOffset As Integer = 28

    Private Const _dwFlagsOffset As Integer = 32

    Private Const _exeFileOffset As Integer = 36

    Private Const _memoryBaseOffset As Integer = 556

    Private Const _accessKeyOffset As Integer = 560

    Private Const _size As Integer = 564

    Private Const _maxPath As Integer = 260

    <CLSCompliant(False)> _
    Public Size As UInteger

    <CLSCompliant(False)> _
    Public Usage As UInteger

    <CLSCompliant(False)> _
    Public ProcessID As UInteger

    <CLSCompliant(False)> _
    Public DefaultHeapID As UInteger

    <CLSCompliant(False)> _
    Public ModuleID As UInteger

    <CLSCompliant(False)> _
    Public Threads As UInteger

    <CLSCompliant(False)> _
    Public ParentProcessID As UInteger

    Public PriClassBase As Integer

    <CLSCompliant(False)> _
    Public Flags As UInteger

    Public ExeFile As String

    <CLSCompliant(False)> _
    Public MemoryBase As UInteger

    <CLSCompliant(False)> _
    Public AccessKey As UInteger

    Private Shared Function GetUInt(ByVal aData As Byte(), ByVal Offset As Integer) As UInteger
        Return BitConverter.ToUInt32(aData, Offset)
    End Function

    Private Shared Sub SetUInt(ByVal aData As Byte(), ByVal Offset As Integer, ByVal Value As Integer)
        Dim buint As Byte() = BitConverter.GetBytes(Value)
        Buffer.BlockCopy(buint, 0, aData, Offset, buint.Length)
    End Sub

    Private Shared Function GetUShort(ByVal aData As Byte(), ByVal Offset As Integer) As UShort
        Return BitConverter.ToUInt16(aData, Offset)
    End Function

    Private Shared Sub SetUShort(ByVal aData As Byte(), ByVal Offset As Integer, ByVal Value As Integer)
        Dim bushort As Byte() = BitConverter.GetBytes(CShort(Value))
        Buffer.BlockCopy(bushort, 0, aData, Offset, bushort.Length)
    End Sub

    Private Shared Function GetString(ByVal aData As Byte(), ByVal Offset As Integer, ByVal Length As Integer) As String
        Dim sReturn As String = Encoding.Unicode.GetString(aData, Offset, Length)
        Return sReturn
    End Function

    Private Shared Sub SetString(ByVal aData As Byte(), ByVal Offset As Integer, ByVal Value As String)
        Dim arr As Byte() = Encoding.ASCII.GetBytes(Value)
        Buffer.BlockCopy(arr, 0, aData, Offset, arr.Length)
    End Sub


    Public Sub New()
    End Sub

    Public Sub New(ByVal aData As Byte())
        Size = GetUInt(aData, _sizeOffset)
        Usage = GetUInt(aData, _usageOffset)
        ProcessID = GetUInt(aData, _processIDOffset)
        DefaultHeapID = GetUInt(aData, _defaultHeapIDOffset)
        ModuleID = GetUInt(aData, _moduleIDOffset)
        Threads = GetUInt(aData, _threadsOffset)
        ParentProcessID = GetUInt(aData, _parentProcessIDOffset)
        PriClassBase = CLng(GetUInt(aData, _priClassBaseOffset))
        Flags = GetUInt(aData, _dwFlagsOffset)
        ExeFile = GetString(aData, _exeFileOffset, _maxPath)
        MemoryBase = GetUInt(aData, _memoryBaseOffset)
        AccessKey = GetUInt(aData, _accessKeyOffset)
    End Sub

    Public Function ToByteArray() As Byte()
        Dim aData As Byte()
        aData = New Byte(_size - 1) {}
        SetUInt(aData, _sizeOffset, _size)
        Return aData
    End Function

    Public ReadOnly Property Name() As String
        Get
            Return ExeFile.Substring(0, ExeFile.IndexOf(vbNullChar))
        End Get
    End Property

    <CLSCompliant(False)> _
    Public ReadOnly Property PID() As ULong
        Get
            Return ProcessID
        End Get
    End Property

    <CLSCompliant(False)> _
    Public ReadOnly Property BaseAddress() As ULong
        Get
            Return MemoryBase
        End Get
    End Property

    <CLSCompliant(False)> _
    Public ReadOnly Property ThreadCount() As ULong
        Get
            Return Threads
        End Get
    End Property


End Class



Public Class Process

    Private Const TH32CS_SNAPPROCESS As Integer = 2

    <CLSCompliant(False)> _
    <DllImport("toolhelp.dll")> _
    Public Shared Function CreateToolhelp32Snapshot(ByVal flags As UInteger, ByVal processid As UInteger) As IntPtr
    End Function

    <DllImport("toolhelp.dll")> _
    Public Shared Function CloseToolhelp32Snapshot(ByVal handle As IntPtr) As Integer
    End Function

    <DllImport("toolhelp.dll")> _
    Public Shared Function Process32First(ByVal handle As IntPtr, ByVal pe As Byte()) As Integer
    End Function

    <DllImport("toolhelp.dll")> _
    Public Shared Function Process32Next(ByVal handle As IntPtr, ByVal pe As Byte()) As Integer
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function OpenProcess(ByVal flags As Integer, ByVal fInherit As Boolean, ByVal PID As IntPtr) As IntPtr
    End Function

    Private Const PROCESS_TERMINATE As Integer = 1

    <DllImport("coredll.dll")> _
    Private Shared Function TerminateProcess(ByVal hProcess As IntPtr, ByVal ExitCode As UInteger) As Boolean
    End Function

    <DllImport("coredll.dll")> _
    Private Shared Function CloseHandle(ByVal handle As IntPtr) As Boolean
    End Function


    Private _processName As String

    Private _handle As Long

    Private _threadCount As Long

    Private _baseAddress As Long

    Public Sub New()
    End Sub

    Private Sub New(ByVal id As Long, ByVal procname As String, ByVal threadcount As Long, ByVal baseaddress As Long)
        _handle = id
        _processName = procname
        _threadCount = threadcount
        _baseAddress = baseaddress
    End Sub

    Public Shared Function GetProcesses() As Process()
        Dim procList As ArrayList = New ArrayList()
        Dim handle As IntPtr = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0)
        If CInt(handle) > 0 Then
            Try
                Dim peCurrent As ProcessEntry32
                Dim pe32 As ProcessEntry32 = New ProcessEntry32()
                Dim peBytes As Byte() = pe32.ToByteArray()
                Dim retval As Integer = Process32First(handle, peBytes)
                While retval = 1
                    peCurrent = New ProcessEntry32(peBytes)
                    Dim proc As Process = New Process(CLng(peCurrent.PID), peCurrent.Name, CLng(peCurrent.ThreadCount), CLng(peCurrent.BaseAddress))
                    procList.Add(proc)
                    retval = Process32Next(handle, peBytes)
                End While
            Catch ex As Exception
                Throw New Exception("Exception : " & ex.Message)
            End Try

            CloseToolhelp32Snapshot(handle)
            Return CType(procList.ToArray(GetType(Process)), Process())
        Else
            Throw New Exception("can not create a snapshot")
        End If
    End Function

    Public Overrides Function ToString() As String
        Return _processName
    End Function

    Public ReadOnly Property BaseAddress() As Long
        Get
            Return _baseAddress
        End Get
    End Property

    Public ReadOnly Property ThreadCount() As Long
        Get
            Return _threadCount
        End Get
    End Property

    Public ReadOnly Property Handle() As Long
        Get
            Return _handle
        End Get
    End Property

    Public ReadOnly Property ProcessName() As String
        Get
            Return _processName
        End Get
    End Property

    Public ReadOnly Property BaseAddess() As Long
        Get
            Return _baseAddress
        End Get
    End Property

    Public Sub Kill()
        Dim hApp As IntPtr
        hApp = OpenProcess(PROCESS_TERMINATE, False, _handle)
        TerminateProcess(hApp, 0)
        CloseHandle(hApp)
    End Sub

End Class
