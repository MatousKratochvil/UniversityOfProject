using System.Text.RegularExpressions;

namespace Core;

public partial class CoreRegex
{
	[GeneratedRegex("")]
	public static partial Regex Empty();

	[GeneratedRegex(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*(\.[a-z]{2,})$")]
	public static partial Regex CheckForEmail();

	[GeneratedRegex(@"^(\+420)? ?[1-9][0-9]{2,3} ?[0-9]{3} ?[0-9]{3}$")]
	public static partial Regex CheckForPhoneNumber();

	[GeneratedRegex(@"^\d{5}$")]
	public static partial Regex CheckForZipCode();
}