// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using static ChainOfResposibility.implementaion;
using Document = ChainOfResposibility.implementaion.Document;

Console.WriteLine("Chain of Responsibility");

var valid = new Document("How to Avoid Java Delpement", DateTimeOffset.UtcNow, true, true);
var invalid = new Document("How to Avoid Java Delpement", DateTimeOffset.UtcNow, false, true);

var documentHandlerChain = new DocumentTitleHandler();
documentHandlerChain.SetSuccessor(new DocumentLastModifiedHandler())
	.SetSuccessor(new DocumentLastModifiedHandler())
	.SetSuccessor(new DocumentApprovedByLitigation())
	.SetSuccessor(new DocumentApprovedByManagment());

try
{
	documentHandlerChain.Handle(valid);
	Console.WriteLine("Valid is valid");
	documentHandlerChain.Handle(invalid);
	Console.WriteLine("invalid is invalid");
}
catch (ValidationException ex)
{
	Console.WriteLine(ex.Message);
}

Console.ReadLine();