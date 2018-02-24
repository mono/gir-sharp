using System;
namespace Gir
{
	public interface IGeneratable
	{
		//void Process();
		void Generate(GenerationOptions opts);
	}

	public interface IType
	{
		string CType { get; set; }
	}
}
