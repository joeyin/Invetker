$(window).ready(function() {

  var userModal = new bootstrap.Modal('#userModal');

  $("#signinup").click(function() {
    userModal.show();
  });

  document.querySelector("form[name='login']").onsubmit = function (e) {
    e.preventDefault();

    this.classList.add('was-validated');
    $("#confirm-password").parent().find(".custom-invalid-feedback:eq(0)").hide();

    if ($("#password").val().trim() !== $("#confirm-password").val().trim()) {
      $("#confirm-password").get(0).setCustomValidity('no match');
      $("#confirm-password").parent().find(".custom-invalid-feedback:eq(0)").show();
      return;
    }

    if (document.querySelector("form[name='login']").checkValidity()) {
      $.ajax({
        method: "POST",
        url: "user/register",
        data: {
          name: $("#name").val().trim(),
          email: $("#email").val().trim(),
          password: $("#password").val().trim(),
        }
      }).done(function() {
        userModal.hide();
        console.log('success')
      });
    }
  }
})
