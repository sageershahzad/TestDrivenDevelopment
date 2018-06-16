using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    public static class CustomAsserts
    {
        public static void IsInRange(this Assert assert,
                                     int actual,
                                     int expectedMinVal,
                                     int expectedMaxVal)
        {
            if (actual < expectedMinVal || actual > expectedMaxVal)
            {
                throw new AssertFailedException($"{actual} was not in the range {expectedMinVal} - {expectedMaxVal}");
            }
        }


        public static void AllItemsNotNullOrWhiteSpace(this CollectionAssert collectionAssert,
                                                        ICollection<string> collection)
        {
            foreach (var item in collection)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    throw new AssertFailedException("One or more items are null or white space");
                }

                Console.WriteLine(item);
            }

        }


        public static void AllItemsSatisfy<T>(this CollectionAssert collectionAssert,
            ICollection<T> collection,
            Predicate<T> predicate)
        {
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    throw new AssertFailedException("All Items Do Not satisfy Predicate");
                }

                Console.WriteLine(item);
            }

        }
    }
}
