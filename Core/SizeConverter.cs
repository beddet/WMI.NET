namespace Core
{
	public static class SizeConverter
	{
		private static double ConvertOneStepUp(double bytes)
		{
			return bytes*1024;
		}

		private static double ConvertTwoStepsUp(double bytes)
		{
			return bytes*1048576; //1024*1024
		}

		private static double ConvertThreeStepsUp(double bytes)
		{
			return bytes * 1073741824; //1024*1024*1024
		}

		private static double ConvertOneStepDown(double kb)
		{
			return kb/1024;
		}

		private static double ConvertTwoStepsDown(double mb)
		{
			return mb / 1048576;//1024*1024
		}

		private static double ConvertThreeStepsDown(double amount)
		{
			return amount / 1073741824;//1024*1024*1024
		}

		public static double BytesToKilobytes(double bytes)
		{
			return ConvertOneStepUp(bytes);
		}

		public static double BytesToMegabytes(double bytes)
		{
			return ConvertTwoStepsUp(bytes);
		}

		public static double BytesToGigabytes(double bytes)
		{
			return ConvertThreeStepsUp(bytes);
		}

		public static double KilobytesToBytes(double kb)
		{
			return ConvertOneStepDown(kb);
		}

		public static double KilobytesToMegabytes(double kb)
		{
			return ConvertOneStepUp(kb);
		}

		public static double KilobytesToGigaBytes(double kb)
		{
			return ConvertTwoStepsUp(kb);
		}

		public static double MegaBytesToBytes(double mb)
		{
			return ConvertTwoStepsDown(mb);
		}

		public static double MegaBytesToKiloBytes(double mb)
		{
			return ConvertOneStepDown(mb);
		}

		public static double MegaBytesToGigaBytes(double mb)
		{
			return ConvertOneStepUp(mb);
		}

		public static double GigabytesToMegaByte(double gb)
		{
			return ConvertOneStepDown(gb);
		}

		public static double GigabytesToKiloBytes(double gb)
		{
			return ConvertTwoStepsDown(gb);
		}

		public static double GigabytesToBytes(double gb)
		{
			return ConvertThreeStepsDown(gb);
		}
	}
}