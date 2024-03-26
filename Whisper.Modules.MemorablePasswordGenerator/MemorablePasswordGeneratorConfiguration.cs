using System;
using System.Collections.Generic;
using System.Text;
using UniForm.Core.Attributes.Composition;
using Whisper.Core.Models.Generation;

namespace Whisper.Modules.MemorablePasswordGenerator
{
	public class MemorablePasswordGeneratorConfiguration : GeneratorConfigurationBase
	{
        public MemorablePasswordGeneratorConfiguration()
        {

        }

        public enum Adjectives { Happy, Funny, Angry, Depressing }

        public enum Nouns
        {
            Animals, Technology, Folklore,
            Insults,
        }

        [UniFormField("Adjectives")]
        public Adjectives SelectedAdjective { get; set; } = Adjectives.Happy;

        [UniFormField("Nouns")]
        public Nouns SelectedNoun { get; set; } = Nouns.Animals;
    }
}
