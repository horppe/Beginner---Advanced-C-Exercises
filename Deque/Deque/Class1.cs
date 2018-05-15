using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    class Class1
    {
        //Unsed code
        //public void Remove(int index)
        //{
        //    if (index < 0 || index >= count)
        //    {
        //        throw new IndexOutOfRangeException("Invalid index");
        //    }

        //    int countDiv = (count / 2) + 1;
        //    if (index <= countDiv)
        //    {
        //        Node tempNode = head;

        //        if (index == 0)
        //        {   //if the head is being removed, point the new element at the next element after the head
        //            //and also make the new element the new head
        //            head = head.next;
        //            head.prev = null;
        //        }
        //        else
        //        {   //Traverse through the list from the head to get the element(tempNode) to be removed
        //            int cnt = 0;
        //            while (cnt < index)
        //            {
        //                tempNode = tempNode.next;
        //                cnt++;
        //            }
        //            //Make the previous element before tempNode point to the next element after tempNode
        //            tempNode.prev.next = tempNode.next;
        //        }
        //    }
        //    else
        //    {
        //        Node tempNode = tail;
        //        int cnt = count - 1;
        //        while (cnt > index)
        //        {   //Traverse through the list from the tail to get the element(tempNode) to be removed
        //            tempNode = tempNode.prev;
        //            cnt--;
        //        }
        //        tempNode.prev.next = tempNode.next;

        //        if (tempNode.next == null)
        //        {   //If the tail was removed, point the new tail at the element before the tail
        //            tail = tempNode.prev;
        //        }
        //    }
        //    count--;
        //}
    }
}
