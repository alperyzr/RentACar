$(function () {
	$('#autocomplete').autocomplete({
		source: 'http://localhost:60634/Ajax/VehicleComplateRegion?',
		open: function (index, data) {
			var els = $(this);
			console.log('open');
			console.log(data);
			return $("#VehicleRegions").append('<li><a href="'.concat('http://www.bing.com/search?q=', data, '">',data,'</a></li>'));
			//return '<a href="'.concat('http://www.bing.com/search?q=', data, '">', data, '</a>');
		},
		//http://localhost:60634/Ajax/VehicleComplateRegion?term=saw
		count: 10,

		select: function (event, value) {
			console.log('select');
			console.log(this);
			console.log(value);
			//window.location.replace(this.prop('href'));
			return false;
		},

		from: 1,

		close: function () {
			console.log('close');
			console.log(this);
		},

		change: function (event, value) {
			console.log('change');
			console.log(value);
		},

		minimal: 2
	});

	//$(document).dblclick(function () {
	//	console.log('destroy dblclick');
	//	$('#autocomplete').autocomplete('destroy');
	//});
});
