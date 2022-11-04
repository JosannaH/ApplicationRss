using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Exceptions;
using Models;

namespace BusinessLogic
{
    public class Validator
    {
        MessageCreator MessageCreator = new MessageCreator();

        public bool HasValue(string text)
        {
            bool result = true;

            if (string.IsNullOrEmpty(text))
            {
                result = false;
            }
            return result;
        }

        public void IsValidUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute) == false) 
            {
                InvalidUrlException.UrlException("Fel url");
            }
            //bool result = false;
            //try
            //{
            //    result = Uri.IsWellFormedUriString(url, UriKind.Absolute);
            //}
            //catch (UriFormatException)
            //{
            //    throw new InvalidUrlException("Invalid URL.");
            //}
            //    return result;
        }

        public bool IsUniqueEpisode(string episode, Feed feed)
        {
            bool result = false;
            List<Episode> duplicateEpisode;

            try
            {
                duplicateEpisode = feed.ListOfEpisodes.Where(x => x.Name.Equals(episode)).ToList();
            }
            catch (ListNotAccessableException)
            {
                throw new ListNotAccessableException("List of episodes could not be accessed.");
            }
            if ((duplicateEpisode == null) || !duplicateEpisode.Any())
            {
                result = true;
            }
            return result;
        }

        public bool IsUniqueName(string name, List<Feed> listOfFeeds)
        {
            bool result = true;
            List<Feed> existingFeed;

            try
            {
                existingFeed = listOfFeeds.Where(x => x.Name.ToLower().Equals(name.ToLower())).ToList();
            }
            catch (ListNotAccessableException)
            {
                throw new ListNotAccessableException("List of feeds could not be accessed.");
            }
            if ((existingFeed == null) || !existingFeed.Any())
            {
                result = false;
            }
            return result;
        }

        public bool IsUniqueName(string name, List<Category> listOfCategory)
        {
            bool result = false;
            List<Category> existingCategory;

            try
            {
                existingCategory = listOfCategory.Where(x => x.Name.ToLower().Equals(name.ToLower())).ToList();
            }
            catch (ListNotAccessableException)
            {
                throw new ListNotAccessableException("List of categories could not be accessed.");
            }
            if ((existingCategory == null) || !existingCategory.Any())
            {
                result = true;
            }
            return result;
        }

        public bool IsUniqueUrl(string url, List<Feed> listOfFeed)
        {
            bool result = true;
            List<Feed> existingUrl;

            try
            {
                existingUrl = listOfFeed.Where(x => x.Url.ToLower().Equals(url.ToLower())).ToList();
            }
            catch (ListNotAccessableException)
            {
                throw new ListNotAccessableException("List of feeds could not be accessed.");
            }
            if ((existingUrl == null) || !existingUrl.Any())
            {
                result = false;
            }
            return result;
        }

        public string ErrorMessageCreateFeed(string name, string url, string category, List<Feed> listOfFeeds)
        {
            string message = "";
 
            bool nameHasValue = HasValue(name);
            if (!nameHasValue) { message += MessageCreator.EmptyName() + "\n"; }

            bool urlHasValue = HasValue(url);
            if (!urlHasValue) { message += MessageCreator.EmptyUrl() + "\n"; }

            bool categoryHasValue = HasValue(category);
            if (!categoryHasValue) { message += MessageCreator.EmptyName() + "\n"; }

            if (nameHasValue && urlHasValue && categoryHasValue)
            {
                //bool urlIsValid = IsValidUrl(url);
                //if (!urlIsValid) { message += MessageCreator.InvalidUrl(); }

                bool urlIsDuplicate = IsUniqueUrl(url, listOfFeeds);
                if (urlIsDuplicate) { message += MessageCreator.UrlExists() + "\n"; }

                bool nameIsDuplicate = IsUniqueName(name, listOfFeeds);
                if (nameIsDuplicate) { message += MessageCreator.NameExists() + "\n"; }
            }
            return message;
        }

        public string ErrorMessageUpdateFeed(string name, string url, string category, List<Feed> listOfFeeds)
        {
            string message = "";

            bool nameHasValue = HasValue(name);
            if (!nameHasValue) { message += MessageCreator.EmptyName() + "\n"; }

            bool urlHasValue = HasValue(url);
            if (!urlHasValue) { message += MessageCreator.EmptyUrl() + "\n"; }

            bool categoryHasValue = HasValue(category);
            if (!categoryHasValue) { message += MessageCreator.EmptyName() + "\n"; }

            return message;
        }
    }
}
