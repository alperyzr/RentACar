(function ($) {
	/**
	 * $.fn.autocomplete()
	 * Provides suggestions while you type into the field.
	 * NOTE: works only with JSON format!
	 *
	 * Options use like:
	 * $('#autocomplete').autocomplete({
	 *		source: 'http://api.bing.com/osjson.aspx?JsonType=callback&JsonCallback=?',
	 *		open: function(index, data) {
	 *			return '<a href="'.concat('http://www.bing.com/search?q=', data, '">', data, '</a>');
	 *		},
	 *		count: 10,
	 *		select: function() {
	 *			window.location.replace(this.prop('href'));
	 *			return false;
	 *		},
	 *		from: 1,
	 *		close: function() {
	 *			console.log(this);
	 *		},
	 *		change: function(event, value) {
	 *			console.log(value);
	 *		},
	 *		minimal: 2
	 * });
	 *
	 * $(document).dblclick(function() {
	 *		$('#autocomplete').autocomplete('destroy');
	 * });
	 *
	 * @option {String} source - JSON string
	 * @option {Number} [count] - Specifies the number of list items
	 * @option {String} [name] - Specifies default class name for the widget
	 * @option {Number} [css] - Specifies CSS styles
	 * @option {Number} [delay] - Initialize a autocomplete with the delay option
	 * in milliseconds after a keystroke to activate itself.
	 * @option {Boolean} [focus] - Specifies focus event
	 * @option {Number} [minimal] - Initialize a autocomplete with minimum number of characters
	 * a user has to type before the Autocomplete activates
	 * @option {Function} [select] - Supply a callback function to handle the select event
	 * if the event on input element, the value of "this" is input
	 * if the event on <li /> element the value of "this" is <li class="active" />
	 * if the function returns a false initialized event event.peventDefault();
	 * @option {Function} [open] - Triggered when the suggestion menu is opened
	 * @option {Number | String} from - Specifies to the element that holds data.
	 * If passed an array the value must be an numeric array index.
	 * For an object should pass a sting.
	 *
	 * Example:
	 * {{object : {data : {...}}}} // 'from', get data from 'data' property
	 * {[], [...]} // 1, get data from first array index
	 *
	 * Methods use like: $('#input').autocomplete('disable');
	 *
	 * @method {Number} disable - Disable the autocomplete
	 * @method {Number} enable - Enable the autocomplete.
	 * @method {Number} clear - Clear inputs value
	 * @method {Number} destroy - Remove the autocomplete functionality completely
	 * @this: {jQuery Object}
	 * @return: {jQuery Object}
	 **/

	$.fn.autocomplete = function (options) {
		
		var self = this;

		if (!self[0])
			return this;

		var param = $.extend({
			source: '',
			minimal: 0,
			count: -1,
			from: 0,
			delay: 1,
			focus: 1,
			select: null,
			close: null,
			open: function () {
				return '';
			},
			name: 'autocomplete',
			css: {
				top: self.offset().top + this.outerHeight() + 'px',
				left: self.offset().left + 'px',
				width: self.outerWidth() + 'px'
			},
			list: function () {
				return $('.' + param.name);
			}
		}, options || {});

		// Set focus
		if (param.focus || this.data('focus') == 1)
			this.data('focus', 1).focus();

		// Create container for the drop down list
		if (!param.list()[0])
			$('<ul />', { 'class': param.name, css: param.css }).appendTo('body');

		var list = param.list();

		list
			// Set minimal length
			.data('minimal', param.minimal)

			// Set maximal count element
			.data('count', param.count)

			// Set visibility
			.attr('autocomplete', 'off').show();

		// Set methods
		if (typeof options == 'string') {
			// disable / enable methods
			list.data('disable', { disable: 1, enable: 0 }[options]);

			if (list.data('disable'))
				return list.empty();

			// clear method
			if (options == 'clear')
				this.val('');

			// destroy method
			if (options == 'destroy')
				return list.data('destroy', 1).empty();
		}

		// Key codes
		var KEY = { ESC: 27, UP: 38, DOWN: 40, ENTER: 13 };

		// Internal methods for keyboard events
		var keyup = {
			status: [0/* up */, 0 /* down */],

			data: [],

			init: function (self, which) {
				if (which == KEY.UP || which == KEY.DOWN) {
					if (which == KEY.DOWN) {
						// Catch the first event
						if (++this.status[0] > 1)
							this.siblings('next');
						else
							list.children().first().addClass('active');

						// Handle next elements
						this.toggle(1, function () {
							this.status[1] = 0;
						});
					}

					if (which == KEY.UP) {
						this.toggle(0, function () {
							this.siblings('prev');
						});
					}

					// Toggle value
					return self.value = this.data[this.active().index()] || self.value;
				}
				else this.status[0] = 0;
			},

			clear: function (append) {
				// Empty list
				list.empty();

				// Close event
				if (!append && $.isFunction(param.close))
					param.close.call(list);
			},

			toggle: function (i, callback) {
				var child = list.children(),
					data = [child.first(), child.last()];

				if (data[i].hasClass('active')) {
					if (++this.status[i] > 1) {
						data[i].removeClass('active');
						data[!i | 0].addClass('active');
					}
				}
				else
					callback.call(this);

				this.select(keyup.active());
			},

			// Get or remove active element
			active: function (remove) {
				var active = list.find('.active');
				return remove ? active.removeClass('active') : active;
			},

			// Get next siblings element
			siblings: function (route) {
				return this.active()[route]().toggleSiblings('active');
			},

			// Callback for selected element
			select: function (active) {
				param.select.call(active, list);
				return this;
			},

			// Append data into list
			append: function (data) {
				// Erase previous data
				keyup.clear(true);

				var li = [], i = 0;

				// Append data into UL
				$.each(data, function (index, Item1) {
					if (param.count != -1 && i++ >= param.count)
						return false;
					li.push('<li>' + param.open(index, Item1) + '</li>');
				});

				$(li.join('')).appendTo(list);

				// Required for fast typing
				if (!this.value)
					keyup.clear();
			}
		};

		this.on({
			keyup: function (event) {
				// Check on the availability
				if (list.data('disable') || list.data('destroy') || this.value.length < list.data('minimal'))
					return keyup.clear();

				var value = $.trim(this.value);

				// Enter event
				if (event.which == KEY.ENTER)
					return keyup.select(this).clear();

				// Hide list and erase the value
				if (event.which == KEY.ESC || !value)
					return keyup.clear();

				// Change event
				if ($.isFunction(param.change))
					param.change.call(list, event, value);

				// If Up or Down event
				if (keyup.init(this, event.which))
					return -1;

				var self = this;

				// Takes a well-formed JSON string
				window.setTimeout(function () {
					$.getJSON(param.source, {
						term: value
					},
						function (data) {
							keyup.append.call(self, keyup.data = param.from ? data[param.from] : data);
						});
				}, param.delay);
			},

			blur: function () {
				keyup.clear();
			}
		});

		// Hover event
		list.on('hover', 'li', function (event) {
			$(this).toggleSiblings('active');
			keyup.select(this);

			if (event.type == 'mouseleave')
				keyup.active(true);
		});

		return this;
	};

	/**
	 * $.fn.toggleSiblings()
	 * Adds a class for each element in the set of matched elements
	 * and removes all siblings (except active)
	 * @params {attr} Class name presented by String
	 * @params {element} Any attribute or tag presented by String
	 * @this: {jQuery Object}
	 * @return: {jQuery Object}
	 **/
	$.fn.toggleSiblings = function (attr, element) {
		attr && $(this).addClass(attr).siblings(element || '').removeClass(attr);
		return this;
	};
})(jQuery);
