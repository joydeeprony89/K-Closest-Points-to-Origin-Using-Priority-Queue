using System;
using System.Collections.Generic;

namespace K_Closest_Points_to_Origin
{
  class Program
  {
    static void Main(string[] args)
    {
      var points = new int[3][] { new int[] { 3, 3}, new int[] { 5, -1 }, new int[] { -2, 4 } };
      Solution s = new Solution();
      var result = s.KClosest(points, 2);
      foreach(var res in result)
      {
        Console.WriteLine(string.Join(",", res));
      }
    }
  }

  public class Solution
  {
    public int[][] KClosest(int[][] points, int k)
    {
      PriorityQueue<(int, int), double> priorityQueue = new PriorityQueue<(int, int), double>();
      foreach(var point in points)
      {
        int x = point[0];
        int y = point[1];
        var distance = Math.Sqrt(((x * x) + (y * y)));
        priorityQueue.Enqueue((x, y), distance);
      }

      var result = new int[k][];
      int index = 0;
      while (k > 0)
      {
        var point = priorityQueue.Dequeue();
        result[index] = new int[] { point.Item1, point.Item2 };
        index++;
        k--;
      }

      return result;
    }
  }
}
