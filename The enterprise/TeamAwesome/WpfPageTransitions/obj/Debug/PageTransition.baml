   M S B A M L   `   `   `  ����M  IWpfPageTransitions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfPageTransitionsWpfPageTransitions  5      '    !WpfPageTransitions.PageTransition   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:WpfPageTransitions     5        � 	Resources  5	       �� 
TargetType �� Property �� Value(   "WpfPageTransitions.CenterConverter   centerConverter  SlideIn g� Duration �� TargetProperty t� From	 t� To g� DecelerationRatio	 g� 
SpeedRatio  SlideOut
 g� AccelerationRatio  SlideReversedIn  SlideReversedOut��%�  '��       &	  n     &	 �     &	     &	 �    &	     �� 5      " ��6
   .�5      ��  �@�LayoutTransform 5      �� 5      5      5        5   
   6    �� 5   
   .��5      t� $ 0:0:.17D�6!   $ Margin�64   $ 500,0,-500,0X�6W   $ 0X�6k   $ .5Q�6r   $	 1Q�6�   5      �� 5   
   .��5      t� $ 0:0:.1D�6!   $ Margin�63   $ -500,0,500,0X�6V   $
 .9Q�6h   $
	 0.88Q�6   5      �� 5   
   .��5       t� $ 0:0:.25D�6!   $ Margin�64   $ -500,0,500,0X�6W   $ 0X�6k   $ .5Q�6r   $	 1Q�6�   5!      �� 5#   
   .��5$      t� $ 0:0:.1D�6!   $ Margin�63   $ 500,0,-500,0X�6V   $
 .9Q�6h   $
	 0.88Q�6   5%      5'      .��5)      � -   5        $
��page��5)      .+�5+      �� -   5        $��contentPresenter��5+      z�5,      V� 5-      .~�5.      ��  �� ScaleX$ 1Q�6    �� ScaleY$ 1Q�6!    �� CenterX 5/   
   ��  �� RelativeSource ��  �� AncestorType$
 GridL� �� Mode$ FindAncestor=� �� Path$ ActualWidth� �� 	Converter# [   �� CenterY 50   
   ��  �� $
 GridL�$ FindAncestor=�$ ActualHeight�# [  �� 51       �� AngleX$ 0Q�6    �� AngleY$ 0Q�6     �� CenterX 52      ��  �� $
 GridL�$ FindAncestor=�$ ActualWidth�# [   �� CenterY 53      ��  �� $
 GridL�$ FindAncestor=�$ ActualHeight�# [  �� 54       �� Angle$ 0Q�6    �� CenterX 55      ��  �� $
 GridL�$ FindAncestor=�$ ActualWidth�# [   �� CenterY 56      ��  �� $
 GridL�$ FindAncestor=�$ ActualHeight�# [  T� 57       T� X$ 0Q�6    T� Y$ 0Q�6    58      5:      5<      5>      