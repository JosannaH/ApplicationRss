

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using BusinessLogic.Exceptions;
using DataAccess;
using Models;
using static System.Net.Mime.MediaTypeNames;

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

        public bool IsValidUrl(string url)
        {
            bool result = true;



            //Uri uri;
            //result = Uri.TryCreate(url, UriKind.Absolute, out uri)
            //    && (uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp);


            //Uri uri = new Uri(url);
            //result = uri.IsWellFormedOriginalString();

            //WebRequest request = WebRequest.Create(url);
            //WebResponse response;
            //
            //try
            //{
            //    response = request.GetResponse();
            //}
            //catch
            //{
            //    throw new InvalidUrlException("Invalid URL.");
            //}

            //if(response == null) 
            //{ 
            //    result = false; 
            //}
            return result;
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
                existingFeed = listOfFeeds.Where(x => x.Name.Equals(name)).ToList();
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
            bool result = true;
            List<Category> existingCategory;

            try
            {
                existingCategory = listOfCategory.Where(x => x.Name.Equals(name)).ToList();
            }
            catch (ListNotAccessableException)
            {
                throw new ListNotAccessableException("List of categories could not be accessed.");
            }
            if ((existingCategory == null) || !existingCategory.Any())
            {
                result = false;
            }
            return result;
        }

        public bool IsUniqueUrl(string url, List<Feed> listOfFeed)
        {
            bool result = true;
            List<Feed> existingUrl;

            try
            {
                existingUrl = listOfFeed.Where(x => x.Url.Equals(url)).ToList();
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

        public string ErrorMessageCreate(string name, string url, string category, List<Feed> listOfFeeds)
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
                bool urlIsValid = IsValidUrl(url);
                if (!urlIsValid) { message += MessageCreator.InvalidUrl(); }

                bool urlIsDuplicate = IsUniqueUrl(url, listOfFeeds);
                if (urlIsDuplicate) { message += MessageCreator.UrlExists() + "\n"; }

                bool nameIsDuplicate = IsUniqueName(name, listOfFeeds);
                if (nameIsDuplicate) { message += MessageCreator.NameExists() + "\n"; }
            }
            return message;
        }

        public string ErrorMessageUpdate(string name, string url, string category, List<Feed> listOfFeeds)
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
