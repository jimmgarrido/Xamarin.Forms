using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Xamarin.Forms.Controls
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 70000, "Platform Specifics - Android AdjustPan/AdjustResize")]
	public class PlatformSpecifics_AndroidSoftInputAdjust : TestContentPage
	{
		protected override void Init()
		{
			BackgroundColor = Color.Pink;

			var button1 = GetButton(WindowSoftInputModeAdjust.Pan);
			var button2 = GetButton(WindowSoftInputModeAdjust.Resize);
			var button3 = GetButton(WindowSoftInputModeAdjust.Unspecified);

			var buttons = new StackLayout { Orientation = StackOrientation.Horizontal, Children = { button1, button2, button3 } };

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Children = { buttons,
				new Entry { Text = "1" },
				new Entry { Text = "2" },
				new Entry { Text = "3" },
				new Entry { Text = "4" },
				new Entry { Text = "5" },
				new Entry { Text = "6" },
				new Entry { Text = "7" },
				new Entry { Text = "8" },
				new Entry { Text = "9" },
				new Entry { Text = "10" } }
			};
		}

		static Button GetButton(WindowSoftInputModeAdjust value)
		{
			var button = new Button { Text = value.ToString(), Margin = 20 };
			button.Clicked += (sender, args) =>
			{
				Application.Current.On<Android>().UseWindowSoftInputModeAdjust(value);
			};
			return button;
		}
	}
}