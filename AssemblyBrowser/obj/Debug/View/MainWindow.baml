   M S B A M L   `   `   `  ����J  FAssemblyBrowser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AssemblyBrowserAssemblyBrowser  5   	   G(clr-namespace:AssemblyBrowser.ConvertersAssemblyBrowser.Converters  5   	   %    AssemblyBrowser.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AssemblyBrowser     5   	   9conv(clr-namespace:AssemblyBrowser.Converters     5   	     � Title$  
MainWindow��5	   	   $	��500��6   $	��300��6)    � 	Resources 5
      9   3AssemblyBrowser.Converters.MethodExtensionConverter   methodExtensionConverter��%   &	          5   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.1* �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   ��. .+�5      �� $��Bottom=�6   $��Загрузить��6-   $��30��6A   $	��100��6M   ��6Y   �� *LoadAssemblyCommand+5      R� 5   
   $��1��6   ��6    �� *Assembly.Nodes+��5      �� 5       �� ItemsSource 6+   �� *	Childrens+ �� ItemContainerStyle 5      �� 5       �� 
TargetType" Q�6     �� Triggers 5      ^� 5   "    ^� 
Conditions 5   &   �� 5   *    �� Binding 64   �� *
NodeType+	 �� Value
	 Method6Q   �� 5   *    64   �� *
ObjectType+
 �� 	Converter#
 [  	 True6�   0�5    &   �� 5!   *    �� Property � �� �� Value
 �  ��6G   5#   #   5%      .R�5'      �� ��6    �� *Name+5(      5*      5+      5,      