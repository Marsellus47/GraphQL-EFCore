using GraphQL.Language.AST;

namespace BridgeManagement.Api.Extensions
{
	public static class SelectionSetExtensions
	{
		public static bool ContainsSelection(this SelectionSet selectionSet, string selection, bool caseSensitive = false)
		{
			if (!caseSensitive)
			{
				selection = selection.ToLowerInvariant();
			}

			return selectionSet.ContainsSelection(selection);
		}

		private static bool ContainsSelection(this SelectionSet selectionSet, string selection)
		{
			foreach (var actualSelection in selectionSet.Selections)
			{
				if (actualSelection is Field field)
				{
					if (field.Name.ToLowerInvariant().Equals(selection))
					{
						return true;
					}

					if (field.SelectionSet.ContainsSelection(selection))
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
