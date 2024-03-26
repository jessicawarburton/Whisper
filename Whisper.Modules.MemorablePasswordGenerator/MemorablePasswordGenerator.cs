using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Whisper.Core.Models.Generation;
using static Whisper.Modules.MemorablePasswordGenerator.MemorablePasswordGeneratorConfiguration;

namespace Whisper.Modules.MemorablePasswordGenerator
{
	public class MemorablePasswordGenerator : ContentGeneratorBase<MemorablePasswordContent, MemorablePasswordGeneratorConfiguration>
	{
		public override Guid Id => Guid.Parse("71ed1001-95be-49b3-8e83-1f5aaf95a732");

		public override string Name => "Memorable Password";

		public override string Description => "Generates memorable passwords";


		private readonly Dictionary<char, char> vowelReplacements = new Dictionary<char, char>
		{
			{'a', '@'},
			{'i', '!'},
			{'o', '0'},
			{'s', '$'},
		};

		private List<string> animals = new List<string>
		{
			"Aardvark", "Albatross", "Alligator", "Alpaca", "Platypus", "Anteater", "Antelope", "Duck", "Armadillo",
			"Donkey", "Baboon", "Badger", "Barracuda", "Bat", "Bear", "Beaver", "Bee", "Bison", "Boar", "Buffalo",
			"Butterfly", "Camel", "Capybara", "Caribou", "Cassowary", "Cat", "Caterpillar", "Cattle", "Penquin",
			"Cheetah", "Chicken", "Chimpanzee", "Donkey", "Clam", "Cobra", "Cockroach", "Cod", "Cormorant",
			"Coyote", "Crab", "Crane", "Crocodile", "Crow", "Curlew", "Deer", "Dinosaur", "Kitten", "Dogfish", "Dolphin",
			"Axolotl", "Dove", "Dragonfly", "Duck", "Dugong", "Dunlin", "Eagle", "Echidna", "Eel", "Eland",
			"Elephant", "Elk", "Emu", "Falcon", "Ferret", "Finch", "Fish", "Flamingo", "Fly", "Fox", "Frog",
			"Gaur", "Gazelle", "Gerbil", "Giraffe", "Gnat", "Monkey", "Goat", "Goldfinch", "Goldfish", "Goose",
			"Gorilla", "Goshawk", "Grasshopper", "Platypus", "Guanaco", "Gull", "Hamster", "Hare", "Hawk", "Hedgehog",
			"Heron", "Herring", "Hippopotamus", "Hornet", "Horse", "Human", "Hummingbird", "Hyena", "Ibex", "Ibis",
			"Jackal", "Jaguar", "Possum", "Jellyfish", "Kangaroo", "Kingfisher", "Koala", "Kookaburra", "Kouprey", "Kudu"
		};




		Dictionary<Nouns, List<string>> NounsByType = new Dictionary<Nouns, List<string>>
		{
			{
				Nouns.Animals,
				new List<string>
				{
					"Aardvark", "Albatross", "Alligator", "Alpaca", "Platypus", "Anteater", "Antelope", "Duck", "Armadillo",
					"Donkey", "Baboon", "Badger", "Barracuda", "Bat", "Bear", "Beaver", "Bee", "Bison", "Boar", "Buffalo",
					"Butterfly", "Camel", "Capybara", "Caribou", "Cassowary", "Cat", "Caterpillar", "Cattle", "Penquin",
					"Cheetah", "Chicken", "Chimpanzee", "Donkey", "Clam", "Cobra", "Cockroach", "Cod", "Cormorant",
					"Coyote", "Crab", "Crane", "Crocodile", "Crow", "Curlew", "Deer", "Dinosaur", "Dog", "Dogfish", "Dolphin",
					"Axolotl", "Dove", "Dragonfly", "Duck", "Dugong", "Dunlin", "Eagle", "Echidna", "Eel", "Eland",
					"Elephant", "Elk", "Emu", "Falcon", "Ferret", "Finch", "Fish", "Flamingo", "Fly", "Fox", "Frog",
					"Gaur", "Gazelle", "Gerbil", "Giraffe", "Gnat", "Gnu", "Goat", "Goldfinch", "Goldfish", "Goose",
					"Gorilla", "Goshawk", "Grasshopper", "Grouse", "Guanaco", "Gull", "Hamster", "Hare", "Hawk", "Hedgehog",
					"Heron", "Herring", "Hippopotamus", "Hornet", "Horse", "Human", "Hummingbird", "Hyena", "Ibex", "Ibis",
					"Jackal", "Jaguar", "Possum", "Jellyfish", "Kangaroo", "Kingfisher", "Koala", "Kookaburra", "Kouprey", "Kudu"
				}
			},
			{
				Nouns.Technology,
				new List<string>
				{
					"Algorithm", "API", "Application", "Array", "Backup", "Bandwidth", "Binary", "Bit", "Browser", "Buffer",
					"Bug", "Cache", "Cloud", "Command", "Compiler", "Compression", "CPU", "Cryptocurrency", "Data", "Database",
					"Debug", "Desktop", "Development", "Device", "Digital", "Disk", "DNS", "Document", "Domain", "Download",
					"Email", "Encryption", "Engine", "Ethernet", "File", "Firewall", "Firmware", "Flash", "Framework", "Gateway",
					"Gigabyte", "Graphics", "Grid", "GUI", "Hardware", "Host", "HTML", "HTTP", "Hyperlink", "Icon", "Interface",
					"Internet", "Intranet", "IP", "JavaScript", "Kernel", "Key", "LAN", "Link", "Linux", "Login", "Malware",
					"Memory", "Menu", "Monitor", "Motherboard", "Mouse", "Network", "Node", "Object", "OS", "Packet", "Password",
					"Patch", "Pixel", "Platform", "Plugin", "Protocol", "Provider", "Proxy", "Query", "Queue", "RAM", "Resolution",
					"Router", "Runtime", "Script", "SDK", "Server", "Session", "Socket", "Software", "Spam", "SQL", "SSL",
					"Storage", "String", "Syntax", "System", "Table", "Tag", "Technology", "Template", "Terminal", "Token",
					"URL", "User", "Username", "Utility", "Virtual", "Virus", "Web", "Website", "Widget", "Wiki", "Window",
					"Wireless", "XML", "ZIP"
				}
			},
			{
				Nouns.Folklore,
				new List<string>
				{
					"Aegis", "Aesir", "Alchemist", "Amulet", "Ankh", "Aphrodite", "Apollo", "Ares", "Asura", "Banshee",
					"Basilisk", "Bifrost", "Boggart", "Calypso", "Centaur", "Cerberus", "Chalice", "Chimera", "Circe", "Cyclops",
					"Demiurge", "Dracula", "Dragon", "Dryad", "Dwarf", "Elf", "Elixir", "Fafnir", "Fates", "Faun",
					"Fenrir", "Freyja", "Gandalf", "Gargoyle", "Genie", "Ghoul", "Goblin", "Golem", "Griffin", "Hades",
					"Halcyon", "Harpy", "Hecate", "Hephaestus", "Hera", "Hercules", "Hydra", "Icarus", "Jinn", "Jotunn",
					"Kappa", "Kraken", "Labyrinth", "Leprechaun", "Leviathan", "Loki", "Manticore", "Medusa", "Merlin", "Minotaur",
					"Mjolnir", "Moirai", "Naiad", "Narcissus", "Nemean", "Nidhogg", "Nymph", "Odin", "Ogre", "Olympus",
					"Oracle", "Pandora", "Pegasus", "Phoenix", "Pixie", "Poltergeist", "Poseidon", "Ragnarok", "Salamander", "Satyr",
					"Scepter", "Selkie", "Serpent", "Sibyl", "Siren", "Sphinx", "Sprite", "Succubus", "Talisman", "Thor",
					"Tiamat", "Titans", "Troll", "Unicorn", "Utopia", "Valkyrie", "Vampire", "Vanir", "Vishnu", "Werewolf",
					"Witch", "Wizard", "Wraith", "Wyvern", "Yggdrasil", "Zeus", "Zombie"
				}
			},
			{
				Nouns.Insults,
				new List<string>
				{
					"Buffoon", "Nincompoop", "Lackwit", "Dunderhead", "Clod", "Nitwit", "Dolt", "Dunce", "Ignoramus", "Simpleton",
					"Churl", "Boor", "Lummox", "Oaf", "Rascal", "Scoundrel", "Rogue", "Wretch", "Scalawag", "Varlet",
					"Knave", "Blunderbuss", "Muttonhead", "Blockhead", "Clot", "Loggerhead", "Lout", "Loon", "Mooncalf", "Numskull",
					"Saphead", "Tomfool", "Twit", "Villain", "Viper", "Scamp", "Scallywag", "Sneak", "Snipe", "Swine",
					"Toad", "Weasel", "Cad", "Cur", "Bounder", "Blighter", "Miscreant", "Reprobate", "Blackguard", "Poltroon",
					"Dotard", "Fuddy-duddy", "Fool", "Goon", "Quack", "Charlatan", "Misanthrope", "Tyrant", "Despot", "Mongrel",
					"Poltroon", "Coward", "Milksop", "Sycophant", "Puppet", "Dilettante", "Demagogue", "Zealot", "Radical", "Fanatic",
					"Hypocrite", "Heretic", "Apostate", "Defector", "Traitor", "Turncoat", "Renegade", "Fugitive", "Outlaw", "Brute",
					"Beast", "Savage", "Barbarian", "Neanderthal", "Cretin", "Troglodyte", "Curmudgeon", "Crone", "Harridan", "Termagant"
				}
			}
		};


		Dictionary<Adjectives, List<string>> adjectivesByType = new Dictionary<Adjectives, List<string>>
		{
			{
				Adjectives.Happy,
				new List<string>
				{
					"joyful", "cheerful", "elated", "gleeful", "happy",
					"jubilant", "merry", "radiant", "sunny", "blissful",
					"buoyant", "chipper", "content", "delighted", "ecstatic",
					"enraptured", "euphoric", "exultant", "glad", "gratified",
					"jolly", "lighthearted", "overjoyed", "peppy", "perky",
					"pleased", "sparkling", "thrilled", "tickled", "upbeat",
					"vibrant", "zippy", "bouncy", "bright", "charmed",
					"chirpy", "contented", "convivial", "effervescent", "energetic",
					"enthusiastic", "exhilarated", "exuberant", "festive", "fulfilled",
					"fun-loving", "genial", "glowing", "grateful", "hearty",
					"high-spirited", "hopeful", "inspired", "jovial", "laughing",
					"light", "optimistic", "playful", "positive", "rejoicing",
					"satisfied", "smiling", "spirited", "sprightly", "thankful",
					"uplifted", "warm", "welcoming", "zestful", "animated",
					"beaming", "beatific", "blessed", "brisk", "carefree",
					"cheering", "comfortable", "easygoing", "ebullient", "enlivened",
					"expansive", "freed", "giddy", "harmonious", "heartening",
					"invigorated", "jaunty", "light-hearted", "mirthful", "pumped",
					"refreshed", "relieved", "vivacious", "whimsical", "witty",
					"lucky", "serene", "prosperous", "enchanting"
				}
			},
			{
				Adjectives.Funny,
				new List<string>
				{
					"wacky", "zany", "quirky", "whimsical", "goofy", "silly", "loony", "bizarre", "kooky", "clownish",
					"comical", "hilarious", "laughable", "nutty", "eccentric", "odd", "outrageous", "peculiar", "ridiculous", "slapstick",
					"screwy", "unhinged", "bonkers", "cracked", "cuckoo", "daffy", "daft", "dippy", "dotty", "flaky",
					"freaky", "gaga", "loopy", "ludicrous", "madcap", "mirthful", "offbeat", "off-the-wall", "outlandish", "preposterous",
					"quirked", "sappy", "screaming", "screwball", "snappy", "snarky", "sneaky", "sparky", "spooky", "kook",
					"giddy", "frisky", "frolicsome", "funky", "giggly", "gleeful", "impish", "jolly", "jovial", "joyful",
					"jumpy", "lively", "merry", "mischievous", "naughty", "nifty", "perky", "playful", "prankish", "puckish",
					"rollicking", "roguish", "rascally", "saucy", "sprightly", "spritely", "sunny", "vivacious", "waggish", "whacky",
					"wisecracking", "wizardly", "woozy", "zippy", "zesty", "zingy", "peppy", "pithy", "plucky", "pokey",
					"punny", "rabble-rousing", "raffish", "ragtag", "rambunctious", "rampant", "raspy", "ratty", "rebellious", "reveling"
				}
			},
			{
				Adjectives.Angry,
				new List<string>
				{
					"furious", "irate", "seething", "enraged", "incensed", "livid", "wrathful", "fuming", "outraged", "infuriated",
					"annoyed", "cross", "vexed", "irritated", "exasperated", "aggravated", "irked", "piqued", "provoked", "maddened",
					"boiling", "sizzling", "burning", "blazing", "flaming", "glowering", "smoldering", "galled", "choleric", "stormy",
					"thunderous", "tumultuous", "volatile", "explosive", "rabid", "berserk", "wild", "crazy", "unhinged", "maniacal",
					"bitter", "acerbic", "acrid", "harsh", "harsh", "stinging", "sharp", "scathing", "sour", "acidic", "caustic",
					"mordant", "biting", "venomous", "vitriolic", "malevolent", "spiteful", "malicious", "vindictive", "nasty", "savage",
					"brutal", "merciless", "ruthless", "barbaric", "barbarous", "cruel", "sadistic", "ferocious", "fierce", "inflammatory",
					"heated", "hot-headed", "hotheaded", "impetuous", "impulsive", "rash", "hasty", "precipitate", "precipitous", "reckless",
					"headstrong", "bullheaded", "stubborn", "obstinate", "intractable", "unyielding", "adamant", "dogged", "mulish", "tenacious"
				}
			},
			{
				Adjectives.Depressing,
				new List<string>
				{
					"bleak", "dismal", "dreary", "grim", "somber", "sorrowful", "morose", "mournful", "woeful", "melancholy",
					"dejected", "despondent", "disheartened", "hopeless", "despairing", "downcast", "downhearted", "gloomy", "glum", "lugubrious",
					"pessimistic", "forlorn", "lonely", "lonesome", "abandoned", "forsaken", "rejected", "depressed", "discouraged", "dispirited",
					"heartbroken", "heartrending", "miserable", "sad", "unhappy", "tearful", "weeping", "wailing", "lamentable", "doleful",
					"anguished", "distressed", "tormented", "troubled", "afflicted", "agonized", "harrowed", "wretched", "miserable", "suffering",
					"afflicted", "ailing", "sick", "ill", "unwell", "painful", "hurting", "aching", "tender", "sensitive", "fragile",
					"vulnerable", "weak", "feeble", "frail", "delicate", "timid", "shy", "faint-hearted", "cowardly", "meek", "submissive",
					"yielding", "compliant", "obedient", "docile", "pliable", "placid", "mild", "gentle", "tame", "dull", "boring",
					"tedious", "monotonous", "repetitive", "uninteresting", "unexciting", "insipid", "flat", "lifeless", "spiritless", "lackluster"
				}
			}
		};







		private string hackerizeText(string password)
		{

			var rnd = new Random();

			char[] characters = password.ToCharArray();

			for (int i = 0; i < characters.Length; i++)
			{
				if (vowelReplacements.ContainsKey(characters[i]) && rnd.NextDouble() < 1.0 / 3.0)
				{

					characters[i] = vowelReplacements[characters[i]];
				}
			}

			return new string(characters);
		}

		private bool validate(string password)
		{

			// Check for at least one uppercase letter
			bool hasUpperCase = Regex.IsMatch(password, "[A-Z]");
			// Check for at least one lowercase letter
			bool hasLowerCase = Regex.IsMatch(password, "[a-z]");
			// Check for at least one special character
			bool hasSpecialChar = Regex.IsMatch(password, "[^a-zA-Z0-9]");
			// Check for at least one digit
			bool hasDigit = Regex.IsMatch(password, "\\d");
			// Check the length of the password is at least 8 characters
			bool isAtLeast8Chars = password.Length >= 8;

			return hasUpperCase && hasLowerCase && hasSpecialChar && hasDigit;

		}


		public string GetRandomAdjectiveFromType(Adjectives adjectiveCategory)
		{
			return GetRandomElementFromList(adjectivesByType[adjectiveCategory]);
		}

		public string GetRandomNounFromType(Nouns nounCategory)
		{
			return GetRandomElementFromList(NounsByType[nounCategory]);
		}

		private string GetRandomElementFromList(List<string> list)
		{
			var random = new Random();
			int index = random.Next(list.Count); // Generates a random index
			return list[index]; // Returns the element at the random index
		}

		protected override MemorablePasswordContent Create(MemorablePasswordGeneratorConfiguration configuration)
		{
			bool validPassword = false;
			string password = "";


			while (!validPassword)
			{
				var rnd = new Random();
				var adjective = GetRandomAdjectiveFromType(configuration.SelectedAdjective);
				var noun = GetRandomNounFromType(configuration.SelectedNoun);
				var hackerizedPassword = hackerizeText(adjective + noun);
				password = hackerizedPassword + rnd.Next(100, 999);
				if (validate(password))
				{
					validPassword = true;
				}
			}

			return new MemorablePasswordContent(password);
		}
	}
}

