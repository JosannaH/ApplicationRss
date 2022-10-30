

namespace BusinessLogic
{
    public static class Validator
    {
        public static bool HasValue(string text)
        {
            bool result = true;

            if (string.IsNullOrEmpty(text))
            {
                result = false;
            }
            return result;
        }

        public static bool IsValidUrl(string url) // check if it can be used to retrieve data
        { 
            bool result = false;

            return result;
        }

        public static bool IsDuplicateUrl(string url)
        {
            bool result = false;

            return result;
        }

        public static bool IsDuplicateCategoryName(string name)
        {
            bool result = false;

            return result;
        }

        public static bool IsDuplicateFeedName(string name)
        {
            bool result = false;

            return result;
        }

    }
}
