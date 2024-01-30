using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibility
{
	internal class implementaion
	{
		public class Document
		{
			public string Title { get; set; }
			public DateTimeOffset LastModified { get; set; }
			public bool ApprovedByLitigation { get; set; }
			public bool ApprovedByManagement { get; set; }

			public Document(string title, DateTimeOffset lastModified, bool approvedByLitigation, bool approvedByManagment)
			{
				Title = title;
				LastModified = lastModified;
				ApprovedByLitigation = approvedByLitigation;
				ApprovedByManagement = approvedByManagment;
			}
		}

		public interface IHandler<T> where T : class
		{
			IHandler<T> SetSuccessor(IHandler<T> successor);

			void Handle(T request);
		}

		public class DocumentTitleHandler : IHandler<Document>
		{
			private IHandler<Document>? _successor;

			public void Handle(Document document)
			{
				if (document.Title == string.Empty)
				{
					throw new ValidationException(new ValidationResult("Title must be filled out", new List<string>() { "Title" }), null, null);
				}

				_successor?.Handle(document);
			}

			public IHandler<Document> SetSuccessor(IHandler<Document> successor)
			{
				_successor = successor;
				return successor;
			}
		}

		public class DocumentLastModifiedHandler : IHandler<Document>
		{
			private IHandler<Document>? _successor;

			public void Handle(Document document)
			{
				if (document.LastModified < DateTime.UtcNow.AddDays(-30))
				{
					throw new ValidationException(new ValidationResult("Document must be modified in the last 30 days", new List<string>() { "Last Modified" }), null, null);
				}

				_successor?.Handle(document);
			}

			public IHandler<Document> SetSuccessor(IHandler<Document> successor)
			{
				_successor = successor;
				return successor;
			}
		}

		public class DocumentApprovedByLitigation : IHandler<Document>
		{
			private IHandler<Document>? _successor;

			public void Handle(Document document)
			{
				if (!document.ApprovedByLitigation)
				{
					throw new ValidationException(new ValidationResult("Document not approved by litigation", new List<string>() { "ApprovedByLitigation" }), null, null);
				}

				_successor?.Handle(document);
			}

			public IHandler<Document> SetSuccessor(IHandler<Document> successor)
			{
				_successor = successor;
				return successor;
			}
		}

		public class DocumentApprovedByManagment : IHandler<Document>
		{
			private IHandler<Document>? _successor;

			public void Handle(Document document)
			{
				if (!document.ApprovedByManagement)
				{
					throw new ValidationException(new ValidationResult("Document not approved by management", new List<string>() { "ApprovedByManagment" }), null, null);
				}

				_successor?.Handle(document);
			}

			public IHandler<Document> SetSuccessor(IHandler<Document> successor)
			{
				_successor = successor;
				return successor;
			}
		}
	}
}