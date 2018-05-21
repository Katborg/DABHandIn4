using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGrid
{
	class test
	{
		static void Main(string[] args)
		{
			SmartGridRepository _sgRepo = new SmartGridRepository();

			var sg = new DAB4.Models.SmartGrid();
			_sgRepo.Add(sg);

			Console.WriteLine($" {_sgRepo.Get(1)}");
			Console.ReadKey();
		}

		
	}


}
