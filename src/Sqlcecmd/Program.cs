using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Synchrosoft.Sqlcecmd
{
	class Program
	{
		private static SqlCeConnection _sqlCeConnection = new SqlCeConnection();

		static void Main(string[] args)
		{
			var dataSource = args[0];
			var fileName = args[1];

			_sqlCeConnection.ConnectionString = dataSource;
			_sqlCeConnection.Open();

			ParseFile(GetCurrentDirectory() + @"\" + fileName);

			_sqlCeConnection.Close();
			_sqlCeConnection.Dispose();
		}

		private static void ParseFile(string filePath)
		{
			using (StreamReader sr = File.OpenText(filePath))
			{
				var sb = new StringBuilder(10000);
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine().Trim();

					if (line.StartsWith(":r"))
					{
						ParseFile(GetCurrentDirectory() + @"\" + line.Substring(3));
					}
					else
					{
						if (line.Equals("GO", StringComparison.OrdinalIgnoreCase))
						{
							ExecuteCommand(sb.ToString());

							sb.Remove(0, sb.Length);
						}
						else
						{
							if (!line.StartsWith("--"))
							{
								sb.Append(line);
								sb.Append(Environment.NewLine);
							}
						}
					}
				}
			}
		}

		private static void ExecuteCommand(string command)
		{
			using (var cmd = new SqlCeCommand())
			{
				cmd.CommandText = command;
				cmd.Connection = _sqlCeConnection;

				cmd.ExecuteNonQuery();
			}
		}

		private static string GetCurrentDirectory()
		{
			return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
		}
	}
}
