using System.Windows.Input;

namespace Task_9_1
{
    internal static class CustomCommands
    {
        public static RoutedUICommand ChangeColor { get; }

        static CustomCommands()
        {
            var gestures = new InputGestureCollection
            {
                new KeyGesture(Key.C, ModifierKeys.Control, "Ctrl+C")
            };

            ChangeColor = new RoutedUICommand(
                "Изменить цвет",
                "ChangeColor",
                typeof(CustomCommands),
                gestures);
        }
    }
}
