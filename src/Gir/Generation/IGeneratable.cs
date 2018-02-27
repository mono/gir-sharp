﻿using System;
using System.Text;

namespace Gir
{
	// Top level generation capability
	public interface IGeneratable
	{
		string Name { get; }
		//void Process();
		void Generate(GenerationOptions opts);
	}

	// IDocumented might end up being added to IGeneratable/IMemberGeneratable
	public interface IDocumented
	{
		Documentation Doc { get; }
	}

	// When generated as part of another generatable
	public interface IMemberGeneratable
	{
		bool NewlineAfterGeneration(GenerationOptions opts);
		void Generate(IGeneratable parent, IndentWriter writer);
	}
}
