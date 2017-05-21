using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GART.Data;

namespace Car_Locator.model
{
    
    public class RestaurantItem : ARItem
    {
        private string cuisine;
        private string name;
        private double rating; // Double between 0 and 10

        /// <summary>
        /// Gets a string that represnts the type of cuisine served at the restaurant.
        /// </summary>
        public string Cuisine
        {
            get
            {
                return cuisine;
            }
            set
            {
                if (cuisine != value)
                {
                    cuisine = value;
                    NotifyPropertyChanged(() => Cuisine);
                }
            }
        }

        /// <summary>
        /// Gets a string that represnts the name of the restaurant.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged(() => Name);

                    // Update the Content property as well for controls that
                    // only show this memeber
                    Content = value;
                }
            }
        }

        /// <summary>
        /// Gets the average user rating of the restaurant.
        /// </summary>
        /// <remarks>
        /// The rating is a double value between 0 and 10.
        /// </remarks>
        public double Rating
        {
            get
            {
                return rating;
            }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    NotifyPropertyChanged(() => Rating);
                }
            }
        }
    }
}
