

//function successContact(result) {
	

//	$('input[name=Name]').val('');
//	$('input[name=Surname]').val('');
//	$('input[name=Email]').val('');
//	$('textarea[name=Message]').val('');
//}



//function select2FormatResultTurkish(result, container, query) {
//    var markup = [];
//    select2FormatResultMarkupTurkish(result.text, query.term, markup);
//    return markup.join("");
//}

//function select2FormatResultMarkupTurkish(text, term, markup) {
//    var match =
//            text
//                .replace("ç", "c").replace("Ç", "C").replace("ğ", "g").replace("Ğ", "G").replace("ı", "i").replace("İ", "I")
//                .replace("ö", "o").replace("Ö", "O").replace("ş", "s").replace("Ş", "S").replace("ü", "u").replace("Ü", "U")
//                .toUpperCase().indexOf
//                (
//                    term
//                        .replace("ç", "c").replace("Ç", "C").replace("ğ", "g").replace("Ğ", "G").replace("ı", "i").replace("İ", "I")
//                        .replace("ö", "o").replace("Ö", "O").replace("ş", "s").replace("Ş", "S").replace("ü", "u").replace("Ü", "U")
//                        .toUpperCase()
//                ),
//            tl = term.length;

//    if (match < 0) {
//        markup.push(text);
//        return;
//    }

//    markup.push(text.substring(0, match));
//    markup.push("<span class='select2-match'>");
//    markup.push(text.substring(match, match + tl));
//    markup.push("</span>");
//    markup.push(text.substring(match + tl, text.length));
//}

//$(document).ready(function () {
//	$(".tab_baslik li").click(function () {
//		if ($(this).hasClass('tab_aktif'))
//			return;

//		var url = $(this).data('url');

//		if (url != null) {

//			window.location.href = url;
//			return;
//		}

//		var tabIndex = $(this).closest("ul").find("li").index(this);

//		$(this).closest(".tab_kap").find(".tab_baslik > li").removeClass('tab_aktif').eq(tabIndex).addClass('tab_aktif');
//		$(this).closest(".tab_kap").find(".tab_kutular > li").removeClass('tab_aktif').eq(tabIndex).addClass('tab_aktif');
//		baslat();
//	});

//	$("dl.dropdown dt a").click(function () {
//		$(this).closest("dl").find("dd ul").toggle();
//	});

//	$("dl.dropdown dd ul li").click(function () {
//		var item = $(this).find("a");

//		$(this).closest("dl").find("dt a").html(item.html());
//		$(this).closest("ul").hide();

//		$(this).closest("dl").trigger('change', item.find('span.value').text());
//	});

//	$(document).bind('click', function (e) {
//		var clicked = $(e.target);

//		if (!clicked.parents().hasClass("dropdown"))
//			$("dl.dropdown dd ul").hide();
//	});

//	$('.datepicker').Zebra_DatePicker({
//		direction: true
//	});

//	$('.datepicker-any').Zebra_DatePicker({
//		readonly_element: false
//	});

//	$('.slides').slides({
//		preload: true,
//		generateNextPrev: true,
//		play: 6000
//	});

//	$('dl#cultureSelector').bind('change', function (event, cultureCode) {
//		if (cultureCode == 'en') {
//			setTimeout(function () {
//				location.href = '/' + cultureCode + '/CultureChange?Culture=' + cultureCode;
//			}, 900);
//		} else {
//			setTimeout(function () {
//				location.href = '/' + cultureCode + '/CultureChange?Culture=' + cultureCode;
//			}, 900);
//		}
//	});

//	/*Arama*/

//});

//(function () {
//	var cx = '005341830093586498347:vm0i4glk7rm';
//	var gcse = document.createElement('script'); gcse.type = 'text/javascript'; gcse.async = true;
//	gcse.src = (document.location.protocol == 'https:' ? 'https:' : 'http:') + '//www.google.com.tr/cse/cse.js?cx=' + cx;
//	var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(gcse, s);
//})();


