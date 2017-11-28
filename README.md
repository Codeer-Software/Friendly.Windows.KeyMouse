# Friendly.Windows.KeyMouse
======================

## Features ...
Key mouse emulation can be performed on Windows applications at high speed and with high accuracy.
This library is built on Friendly Layer.
Valid for applications created with Win32, WinForms, WPF.

Please use it with these.
Codeer.Friendly.Windows.NativeStandardControls
Ong.Friendly.FormsStandardControls
RM.Friendly.WPFStandardControls

## Getting Started
    PM> Install-Package Codeer.Friendly.Windows.KeyMouse

## Samples.
Keybord emulate.
```csharp
var window = WindowControl.FromZTop(app);
var target = new FormsTextBox(window.Dynamic()._keyTest);

//The argument is the same specification as System.Windows.Forms.SendKeys.
target.SendKeys("aBc");

//CONTROL + Q
target.SendControlAndKey(Keys.Q);

//SHIFT + Q
target.SendShiftAndKey(Keys.A);

//ALT + Q
target.SendAltAndKey(Keys.Q);

//CONTROL + SHIFT + ALT + Q
target.SendModifyAndKey(true, true, true, Keys.Q);
```

Mouse emulate.
```csharp
var window = WindowControl.FromZTop(app);
var target = new WindowControl(window.Dynamic()._mouseTest);

//Left click. The coordinates are the center of the control.
target.Click();

//Specify button and specify client coordinates.
target.Click(MouseButtonType.Middle, new Point(4, 5));

//Double click.
target.DoubleClick();
target.DoubleClick(MouseButtonType.Middle, new Point(4, 5));

//Drag & Drop.
var dropTarget = new WindowControl(window.Dynamic()._dropTest);
target.MouseDown(MouseButtonType.Left, new Point(0, 0));
dropTarget.MouseUp(MouseButtonType.Left, new Point(2, 3));
```
Keybord and Mouse emulate.
```csharp
var window = WindowControl.FromZTop(app);
var target = new WindowControl(window.Dynamic()._keyMouseTest);

//ALT + MouseClick;
var keybord = app.Keybord();
keybord.Down(Keys.Menu);
target.Click():
keybord.Up(Keys.Menu);
```