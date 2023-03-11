
#pragma warning disable CS0169
#pragma warning disable IDE0051
#pragma warning disable IDE0044

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Shapes;

namespace CodeMarkup.WinUI.Internal
{
    class WinUISymbols
	{
        Style Style;
        Setter Setter;
        
        AdaptiveTrigger AdaptiveTrigger;
        EventTrigger EventTrigger;
        StateTrigger StateTrigger;      

        KeyboardAccelerator KeyboardAccelerator;

        DataTemplateSelector DataTemplateSelector;

        // ------ Basic Input -------

        Button Button;//
        DropDownButton DropDownButton;//
        HyperlinkButton HyperlinkButton;
        RepeatButton RepeatButton;
        ToggleButton ToggleButton;
        SplitButton SplitButton;
        ToggleSplitButton ToggleSplitButton;
        CheckBox CheckBox;
        ColorPicker ColorPicker;
        ComboBox ComboBox;
        Hyperlink Hyperlink;
        RadioButtons RadioButtons;
        RadioButton RadioButton;
        RatingControl RatingControl;
        Slider Slider;
        ToggleSwitch ToggleSwitch;

        // ------ Collections -------

        FlipView FlipView;
        GridView GridView;
        ListBox ListBox;
        ListView ListView;
        RefreshContainer RefreshContainer;
        RefreshVisualizer RefreshVisualizer;
        TreeView TreeView;
        TreeViewItem TreeViewItem;

        // ------ Date & Time -------

        CalendarDatePicker CalendarDatePicker;
        CalendarView CalendarView;
        DatePicker DatePicker;
        TimePicker TimePicker;

        // ------ dialogs & flyouts -------

        ContentDialog ContentDialog;
        Flyout Flyout;
        TeachingTip TeachingTip;

        // ------ Layout -------

        Frame Frame;
        Border Border;
        Canvas Canvas;
        Expander Expander;
        ItemsRepeater ItemsRepeater;
        UniformGridLayout UniformGridLayout;
        ItemsRepeaterScrollHost ItemsRepeaterScrollHost;
        Grid Grid;
        RelativePanel RelativePanel;
        SplitView SplitView;
        StackPanel StackPanel;
        VariableSizedWrapGrid VariableSizedWrapGrid;
        Viewbox Viewbox;

        // ------ Media -------

        AnimatedVisualPlayer AnimatedVisualPlayer;
        Image Image;
        MediaPlayerElement MediaPlayerElement;
        PersonPicture PersonPicture;
        ElementSoundPlayer ElementSoundPlayer;
        WebView2 WebView2;

        // ------ Menus & toolbars -------

        XamlUICommand XamlUICommand;
        StandardUICommand StandardUICommand;
        CommandBar CommandBar;
        AppBarButton AppBarButton;
        AppBarSeparator AppBarSeparator;
        AppBarToggleButton AppBarToggleButton;
        MenuBar MenuBar;
        MenuBarItem MenuBarItem;
        MenuFlyoutItem MenuFlyoutItem;
        MenuFlyoutSubItem MenuFlyoutSubItem;
        CommandBarFlyout CommandBarFlyout;
        FlyoutShowOptions FlyoutShowOptions;
        MenuFlyout MenuFlyout;
        MenuFlyoutSeparator MenuFlyoutSeparator;
        SwipeItems SwipeItems;
        SwipeItem SwipeItem;
        SwipeControl SwipeControl;

        // ------ Motion -------

        Storyboard Storyboard;
        DoubleAnimation DoubleAnimation;
        CircleEase CircleEase;
        ExponentialEase ExponentialEase;
        BackEase BackEase;
        TransitionCollection TransitionCollection;
        NavigationThemeTransition NavigationThemeTransition;
        EntranceThemeTransition EntranceThemeTransition;
        RepositionThemeTransition RepositionThemeTransition;
        ContentThemeTransition ContentThemeTransition;
        AddDeleteThemeTransition AddDeleteThemeTransition;
        PopupThemeTransition PopupThemeTransition;
        ScalarTransition ScalarTransition;
        Vector3Transition Vector3Transition;
        BrushTransition BrushTransition;
        ParallaxView ParallaxView;

        // ------ Navigation -------

        BreadcrumbBar BreadcrumbBar;
        BreadcrumbBarItem BreadcrumbBarItem;
        NavigationView NavigationView;
        NavigationViewItem NavigationViewItem;
        NavigationViewItemHeader NavigationViewItemHeader;
        Pivot Pivot;
        PivotItem PivotItem;
        TabView TabView;
        TabViewItem TabViewItem;

        // ------ Scrolling -------

        PipsPager PipsPager;
        ScrollViewer ScrollViewer;
        SemanticZoom SemanticZoom;

        // ------ Status & Info -------

        InfoBar InfoBar;
        ProgressBar ProgressBar;
        ProgressRing ProgressRing;

        // ------ Style -------

        AnimatedIcon AnimatedIcon;
        SymbolIcon SymbolIcon;
        SymbolIconSource SymbolIconSource;
        BitmapIcon BitmapIcon;
        BitmapIconSource BitmapIconSource;
        FontIcon FontIcon;
        FontIconSource FontIconSource;
        PathIcon PathIcon;
        PathIconSource PathIconSource;
        ImageIcon ImageIcon;
        ImageIconSource ImageIconSource;
        RadialGradientBrush RadialGradientBrush;

        // ------ Shapes -------

        Rectangle Rectangle;
        Ellipse Ellipse;
        Polygon Polygon;
        Line Line;
        Polyline Polyline;
        Path Path;
        GeometryGroup GeometryGroup;
        LineGeometry LineGeometry;
        EllipseGeometry EllipseGeometry;
        RectangleGeometry RectangleGeometry;

        // ------ Text -------

        AutoSuggestBox AutoSuggestBox;
        NumberBox NumberBox;
        PasswordBox PasswordBox;
        RichEditBox RichEditBox;
        RichTextBlock RichTextBlock;
        Paragraph Paragraph;
        Run Run;
        RichTextBlockOverflow RichTextBlockOverflow;
        TextBlock TextBlock;
        TextBox TextBox;

        // ------ Windowing -------

        Window Window;

    }
}

#pragma warning restore CS0169
#pragma warning restore IDE0051
#pragma warning restore IDE0044