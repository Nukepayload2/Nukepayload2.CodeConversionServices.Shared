# Nukepayload2.CodeConversionServices.Shared
帮助VB写的WPF项目移植为UWP，并且帮助其它语言代码转换为VB代码
本项目需要Nuget包System.Text.Encoding.CodePageshe和一些项目级别导入, 否则无法正常编译。
如果用C#的网页想用这个代码库，新建一个vb的uwp类库，然后添加共享项目引用再编译就行了。
<dlv>
  <ul>
    <li>类名</li>
    <li>功能</li>
  </ul>
  <ul>
    <li>Brushes</li>
    <li>移植WPF的Brushes</li>
  </ul>
  <ul>
    <li>ClipBoard</li>
    <li>移植WPF的ClipBoard</li>
  </ul>
  <ul>
    <li>ColorEx</li>
    <li>颜色与数字转换</li>
  </ul>
  <ul>
    <li>ContentDialogSimulateWindow</li>
    <li>仿WPF的ShowDialog</li>
  </ul>
  <ul>
    <li>GB2312Encoding</li>
    <li>帮助使用GB2312Encoding</li>
  </ul>
  <ul>
    <li>GrammarCastHelper</li>
    <li>帮助C#到VB代码的转换</li>
  </ul>
  <ul>
    <li>Interaction</li>
    <li>实现一些旧的VB库函数</li>
  </ul>
  <ul>
    <li>PinnedPointer</li>
    <li>将结构体或结构体的数组固定，并当作内存块对待</li>
  </ul>
  <ul>
    <li>Pointer</li>
    <li>将结构体或结构体的数组当作内存块对待, 但不固定结构体</li>
  </ul>
</dlv>