namespace UserAccess.Helpers
{
    public static class ValueConverter
    {
        public static bool ConvertToBoolean(string value)
        {
            if (value.Equals("1") || value.ToLower().Equals("true"))
                return true;
            else return false;
        }
        public static string ConvertFromBoolean(string value)
        {
            if (value.ToLower().Equals("true"))
                return "1";
            else
                return "0";
        }
    }
}
