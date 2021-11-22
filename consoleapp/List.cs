using System;

namespace consoleapp
{
    public class List<T>
    {
        private class ListItem
        {
            public T Data;
            public ListItem NextListItem;
        }

        private ListItem _firstListItem;
        private int _length;

        public int Length => _length;

        public void Add(T data)
        {
            // Creating a new list item with the data we passed as an argument
            var listItem = new ListItem { Data = data };

            // If there's no first element, then create one without any links to
            // other elements and return
            if (_firstListItem == null)
            {
                _firstListItem = listItem;
                _length = 1;
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
            _length += 1;
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
        // Index validation 
        private void ValidateIndex(int index)
        {
            if (_firstListItem == null)
                throw new Exception("The list is empty :/");

            if (index >= _length || index < 0)
                throw new Exception($"There's no element for index {index}");
        }
        
        private T GetItem(int index)
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
        
        // Indexer 
        public T this[int index] => GetItem(index);
    }
}