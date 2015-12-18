# FormsEngine
Initial load
	1. Preload all current schemas at application startup (would require restart when adding new schema)
	2. Optimised memory usage http://www.newtonsoft.com/jsonschema/help/html/Performance.htm
	3. I used a basic MVC solution template. Is that useless overhead
	4. Didn't worry about authentication
	5. Used EF but that seems like overkill (simple model, two classes)
	6. We might want to add a group property to the Form model
	7. We might want to add an active to the Form model (index out old forms)
	8. We might want to think about optimising finding the "current" version of a form (i.e. Current property)
	9. How many FormData records are we looking at? Might want the PK to be a long
	10. Subject is the person the form is about so for us at the moment generally a Foundation Trainee. I'm imagining this will be the Turas personId but the Forms engine shouldn't really care
	11. I'm planning on the key data being copied out of the Json not pulled out i.e. The json will also contain the keys and their "labels" at time of creation
	12. Not sure how best to implement workflow. I'd prefer the FormEngine doesn't know anything about it to be honest
		a. Use different instances of Form to record each step of workflow
		b. Allow a form to be updated
			i. Required fields will be a pig
			ii. Probably need to add an audit trail
	13. If a form needs to hold ticket code can I suggest the uniquest part goes at the start of the code
	14. Procedure date is for the date the "thing" was done that the form is about. It may cause problems
	15. I know it's a very silly idea serialising a big string into another big string
	16. No repository because if we change our data layer we're probably throwing the whole lot out
	17. No inheritance but I might if you twist my arm
	18. No dependency injection yet but it'll come with testing. IoC is probably overkill though
	19. Might be an idea to do that self-hosting thing Gerry did way back. If you do can I hitch along as it seems like something that would be good to know
	20. We probably want some sort of logging so we can do performance monitoring without hitting the database; eg. Number of forms filled per day
	21. If we're using Web API we should probably return IHttpActionResult with not found etc
	22. Not sure about the best way to handle read only of the FormData (i.e. For View button)
	23. In the form data controller I think we'll need
		a. GetBySubject - all completed forms for a trainee (used by whatever generates a trainee's portable portfolio)
		b. GetBySubjectAndForm - all completed forms of a type of form
		c. Same as above but just passing back the key values not the form data (for summary pages)
		d. GetByFormForDateRange - all forms of a type CreatedOn in a date range
		e. GetBySubmitter - all for the submitter (show an assessor all)
		f. Get - uses FormData id for a basic read only form
	24. Dammit! Chicken/egg situation. Wasn't planning on allowing the client to pass back the schema as there be dragons but you need the schema before you can parse the json object but the form id is in the json object so...more thunk required. For now I will assume we only have one type of form
		a. Ho ho ho. We have Linq to Json. A wee try catch and that and we're back on the road again
	25. Oh yeah, that reminds me...I've no clue how we handle the reference list situation. Eek!
	26. Damn Json Schema costs money - about the same as a day of a contractor so dig deep!
	27. Do we want to use async. 
	28. Of course Version and Schema are reserved words in the database
	29. I've made a total pig of the client but it's meant to be like this http://www.alpacajs.org/tutorial.html
