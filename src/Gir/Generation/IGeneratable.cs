﻿using System;
using System.Text;

namespace Gir
{
	public interface IGeneratable
	{
		string Name { get; }
		//void Process();
		void Generate(GenerationOptions opts);
	}

	public interface IType
	{
		string CType { get; set; }
	}
}
