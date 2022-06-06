<script type="text/javascript">

	function validateEmail(email) {
		var re = /^(([^<>()[\]\\.,;:\s@@\"]+(\.[^<>()[\]\\.,;:\s@@\"]+)*)|(\".+\"))@@((\[[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\.[0-9]{1, 3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		return re.test(email);
	}

	function formControl(){
		var i = 0;


		var email = $('input[name="Contact.Email"]').val();
		if (!validateEmail(email)) {
			alert('@(HttpUtility.HtmlDecode(Arackiralama.Resources.LanguageFields.ValidEmail))'.replace("&#246;", "ö").replace("&#231;", "ç"));
			$('input[name="Contact.Email"]').css("border", "1px solid #ff0000");
			i++;
		}

		@if(Model.Vehicle.CC_Info == "true"){


	  @Html.Raw(
			"if ($('#CreditCardType').val() == '') {" +
			"alert('" + Arackiralama.Resources.LanguageFields.SelectCardType + "'.replace(/&#252;/g, 'ü').replace('&#231;', 'ç'));" +
			"return false;" +
		"}" +
		"var valid = $.payment.validateCardNumber($('#CardNum').val());" +

		"if (!valid) {" +
			"alert('" + Arackiralama.Resources.LanguageFields.CreditcardValid + "'.replace('&#231;', 'ç'));" +
			"return false;" +
		"}" +

		"var valid = $.payment.validateCardCVC($('#securitycode').val());" +

		"if (!valid) {" +
			"alert('" + Arackiralama.Resources.LanguageFields.CreditcardValid + "'.replace('&#231;','ç'));" +

			"return false;" +
		"}"
		);
  }
		@*if($('#custemail').val()!=$('#custemailconfirm').val())
		{
			alert("@(Html.Raw(Arackiralama.Resources.LanguageFields.MailUnavaible))");
			i++;
		}*@

        var checkControl = $("input[name=onBilgilendirme]:checked").length > 0;
        var campControl = $("input[name=onBilgilendirme]:checked").length > 0;

		if (campControl == 0 && checkControl == 0) {

			alert('@(HttpUtility.HtmlDecode(Arackiralama.Resources.LanguageFields.GeneralTerm))'.replace(/&#214;/g, "ö").replace("&#231;", "ç").replace(/&#246;/g, "ö"));
			i++;
		}
		else if (campControl != 0 && checkControl == 0) {
			alert('@(HttpUtility.HtmlDecode(Arackiralama.Resources.LanguageFields.GeneralTerm1))'.replace(/&#214;/g, "ö").replace("&#231;", "ç").replace(/&#246;/g, "ö"));
			i++;
		}
		else if (campControl == 0 && checkControl != 0) {
			alert('@(HttpUtility.HtmlDecode(Arackiralama.Resources.LanguageFields.GeneralTerm2))'.replace(/&#214;/g, "ö").replace("&#231;", "ç").replace(/&#246;/g, "ö"));
			i++;
		}





		if (i == 0) {
			//$('#reservationBtn').hide();
			//$("#yukle").show();
			$("#rezerv").submit();
		} else {
			return false;
		}
	}
</script>