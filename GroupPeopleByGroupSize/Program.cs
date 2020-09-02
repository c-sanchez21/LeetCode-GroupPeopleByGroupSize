using System;
using System.Collections.Generic;
using System.Text;

/*
Problem: https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to/
There are n people, each of them has a unique ID from 0 to n - 1 and 
each person of them belongs to exactly one group.

Given an integer array groupSizes which indicated that the 
person with ID = i belongs to a group of groupSize[i] persons.

Return an array of the groups where ans[j] contains the IDs of the jth group. 
Each ID should belong to exactly one group and each ID should be present in your answer.
Also if a person with ID = i belongs to group j in your answer, 
then ans[j].length == groupSize[i] should be true.

If there is multiple answers, return any of them. 
It is guaranteed that there will be at least one valid solution for the given input.
*/
namespace GroupPeopleByGroupSize
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<int>> results = GroupThePeople(new int[] { 3, 3, 3, 3, 3, 1, 3 });

            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            foreach(IList<int> list in results)
            {
                sb.Append('[');
                foreach(int i in list)
                {
                    sb.Append(i);
                    sb.Append(',');
                }
                sb.Length--; //Remove the last char
                sb.Append(']');
            }
            sb.Append(']');
            Console.WriteLine(sb.ToString());
        }

        public static IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            Dictionary<int, List<int>> groups = new Dictionary<int, List<int>>();
            IList<IList<int>> results = new List<IList<int>>();
            int key;
            for(int i = 0; i < groupSizes.Length; i++)
            {
                key = groupSizes[i];
                if (!groups.ContainsKey(key))
                    groups.Add(key, new List<int>());

                groups[key].Add(i);

                //Check if the group is at max capacity
                if (groups[key].Count == groupSizes[i])
                {
                    //If so, add the results and clear
                    //for another possible group of the same size
                    results.Add(new List<int>(groups[key].ToArray()));
                    groups[key].Clear();
                }
            }
            return results;
        }
    }
}
