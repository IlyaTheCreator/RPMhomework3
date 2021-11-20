using System;

namespace consoleapp
{
    class Program
    {
        // TESTING
        public static void Main(string[] args)
        {
            // Initial vars
            var intList = new List<int>();
            var stringList = new List<string>();
            var random = new Random();
            
            // Filling the lists with random values
            for (var i = 0; i < 10; i++)
                intList.Add(random.Next(-100, 100));

            stringList.Add("hello");
            stringList.Add("world");
            stringList.Add("from");
            stringList.Add("iluha");
            stringList.Add("bruh");
            
            // Deleting items randomly 
            intList.RemoveAt(random.Next(-1, 12));
            intList.RemoveAt(random.Next(-1, 6));
        }
    }

    class List<T>
    {
        private class ListItem
        {
            public T Data;
            public ListItem NextListItem;
        }

        private ListItem _firstListItem;
        private int _length;

        public void Add(T data)
        {
            // Creating a new list item with the data we passed as an argument
            var listItem = new ListItem { Data = data };

            // If there's no first element, then create one without any links to
            // other elements and return
            if (_firstListItem == null)
            {
                _firstListItem = listItem;
                return;
            }
            
            // Otherwise we create a new variable holding the first element's copy
            // In result of the lines below it's going to contain item before the
            // one we create
            var prevItem = _firstListItem;
            
            // Then we're going through a chain of linked list items from the first
            // one to the end and each time we assign a new value for the previous item
            // until we reach the last one
            while (prevItem.NextListItem != null)
            {
                prevItem = prevItem.NextListItem;
            }
            
            // When we're done, we assign the previous item's object
            // NextListItem field to the last list item (which has no next item)
            prevItem.NextListItem = listItem;
            
            _length++;
        }
        
        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            
            // This variable is meant for iteration below
            var itemBeforeTheOneToDelete = _firstListItem;
                
            // Getting the item right before the one we want to delete
            for (var i = 0; i < index - 1; i++)
            {
                itemBeforeTheOneToDelete = itemBeforeTheOneToDelete.NextListItem;
            }
            
            // Skipping the link for the item we want to delete (deletion itself, basically)
            itemBeforeTheOneToDelete.NextListItem = itemBeforeTheOneToDelete.NextListItem.NextListItem;
            
            _length--;
        }
        
        // ADDITIONAL METHODS
        // Simple index validation 
        private void ValidateIndex(int index)
        {
            if (_firstListItem == null)
                throw new Exception("The list is empty :/");

            if (index >= _length || index <= 0)
                throw new Exception("There's no element for that index.");
        }
        
        public T GetItem(int index)
        {
            ValidateIndex(index);
            
            // This variable is meant for iteration below
            var item = _firstListItem;
            
            // Looping through all the list items and counting their amount until we reach
            // the right one
            for (var i = 0; i < index; i++)
            {
                item = item.NextListItem;
            }
            
            return item.Data;
        }
        
        public int GetIndex(T listItem)
        {
            // If we have the first item, proceed, otherwise - return -1
            if (_firstListItem == null)
            {
                return -1;
            }

            // This variable is meant for iteration below
            var item = _firstListItem;
            var index = 0;
            
            // Increment the index each time when the item from the argument is not equal to 
            // the next item in the iteration and when NextListItem is not null (so we can proceed)
            while (listItem.GetHashCode() != item.Data.GetHashCode() && item.NextListItem != null)
            {
                item = item.NextListItem;
                index++;
            }
            
            return index;
        }
        
        // Indexer 
        public T this[int index] => GetItem(index);
    }
}