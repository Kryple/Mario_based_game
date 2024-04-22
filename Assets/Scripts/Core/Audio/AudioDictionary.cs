using System.Collections.Generic;

public static class AudioDictionary
{
	public static List<string> names = new List<string> {
		"CompressedButton",
		"UncompressedButton",
		"Null",
	};

	public static List<float> lengths = new List<float> {
		0.2002083f,
		0.1364583f,
		0f,
	};
}

public enum AudioEnum
{
	CompressedButton,
	UncompressedButton,
	Null,
}