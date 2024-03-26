using System;
using System.Collections.Generic;
using System.Text;
using Whisper.Core.Modularity;

namespace Whisper.Modules.MemorablePasswordGenerator
{
	public class MemorablePasswordGeneratorModule : IWhisperModule
	{
		public Guid Id => Guid.Parse("0038aa07-6186-4c9b-b5ce-c3ef4692cfab");

		public string Name => nameof(MemorablePasswordGenerator);

		public void LoadModule(IComponentRegistry registry)
		{
			registry.RegisterContentGenerator(new MemorablePasswordGenerator());
		}
	}
}
