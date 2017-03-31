using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WisenetBackOfficeApp.Helpers.Behaviors
{
    class InitBehavior : Behavior<View>
    {

        TapGestureRecognizer tapRecognizer;
        static List<InitBehavior> defaultBehaviors = new List<InitBehavior>();
        static Dictionary<string, List<InitBehavior>> starGroups = new Dictionary<string, List<InitBehavior>>();

        public static readonly BindableProperty GroupNameProperty = BindableProperty.Create("GroupName", typeof(string), typeof(InitBehavior), null, propertyChanged: OnGroupNameChanged);

        public string GroupName
        {
            set { SetValue(GroupNameProperty, value); }
            get { return (string)GetValue(GroupNameProperty); }
        }

        public static readonly BindableProperty RatingProperty = BindableProperty.Create("Rating", typeof(int), typeof(InitBehavior), default(int));

        public int Rating
        {
            set { SetValue(RatingProperty, value); }
            get { return (int)GetValue(RatingProperty); }
        }

        static void OnGroupNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            InitBehavior behavior = (InitBehavior)bindable;
            string oldGroupName = (string)oldValue;
            string newGroupName = (string)newValue;

            // Remove existing behavior from Group
            if (String.IsNullOrEmpty(oldGroupName))
            {
                defaultBehaviors.Remove(behavior);
            }
            else
            {
                List<InitBehavior> behaviors = starGroups[oldGroupName];
                behaviors.Remove(behavior);

                if (behaviors.Count == 0)
                {
                    starGroups.Remove(oldGroupName);
                }
            }

            // Add New Behavior to the group
            if (String.IsNullOrEmpty(newGroupName))
            {
                defaultBehaviors.Add(behavior);
            }
            else
            {
                List<InitBehavior> behaviors = null;

                if (starGroups.ContainsKey(newGroupName))
                {
                    behaviors = starGroups[newGroupName];
                }
                else
                {
                    behaviors = new List<InitBehavior>();
                    starGroups.Add(newGroupName, behaviors);
                }

                behaviors.Add(behavior);
            }

        }


        public static readonly BindableProperty IsStarredProperty = BindableProperty.Create("IsStarred", typeof(bool), typeof(InitBehavior), false, propertyChanged: OnIsStarredChanged);

        public bool IsStarred
        {
            set { SetValue(IsStarredProperty, value); }
            get { return (bool)GetValue(IsStarredProperty); }
        }

        static void OnIsStarredChanged(BindableObject bindable, object oldValue, object newValue)
        {
            InitBehavior behavior = (InitBehavior)bindable;

            if ((bool)newValue)
            {
                string groupName = behavior.GroupName;
                List<InitBehavior> behaviors = null;

                if (string.IsNullOrEmpty(groupName))
                {
                    behaviors = defaultBehaviors;
                }
                else
                {
                    behaviors = starGroups[groupName];
                }

                bool itemReached = false;
                int count = 1, position = 0;
                // all positions to left IsStarred = true and all position to the right is false
                foreach (var item in behaviors)
                {
                    if (item != behavior && !itemReached)
                    {
                        item.IsStarred = true;
                    }
                    if (item == behavior)
                    {
                        itemReached = true;
                        item.IsStarred = true;
                        position = count;
                    }
                    if (item != behavior && itemReached)
                        item.IsStarred = false;

                    item.Rating = position;
                    count++;
                }

            }
        }

        public InitBehavior()
        {
            defaultBehaviors.Add(this);
        }

        protected override void OnAttachedTo(View view)
        {
            tapRecognizer = new TapGestureRecognizer();
            tapRecognizer.Tapped += OnTapRecognizerTapped;
            view.GestureRecognizers.Add(tapRecognizer);
        }

        protected override void OnDetachingFrom(View view)
        {
            view.GestureRecognizers.Remove(tapRecognizer);
            tapRecognizer.Tapped -= OnTapRecognizerTapped;
        }

        void OnTapRecognizerTapped(object sender, EventArgs args)
        {
            //HACK: PropertyChange does not fire, if the value is not changed :-(
            IsStarred = false;
            IsStarred = true;
        }
    }
}
