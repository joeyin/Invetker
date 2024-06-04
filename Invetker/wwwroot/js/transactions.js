

$(function() {
  var start = moment().subtract(7, 'days');
  var end = moment();
  $('input[name="daterange"]').daterangepicker({
    opens: 'right',
    startDate: start,
    endDate: end,
    maxDate: moment(),
    applyButtonClasses: 'btn-warning text-light',
  }, function(start, end, label) {
    console.log(start, end, label)
  });

  $('#datetime').daterangepicker({
    timePicker: true,
    singleDatePicker: true,
    startDate: moment(),
    maxDate: moment(),
    timePicker24Hour: false,
    autoApply: true,
    open: true,
    applyButtonClasses: 'btn-warning text-light',
    locale: {
      format: 'YYYY/MM/DD HH:mm:ss'
    }
  })

  var transactionModal = new bootstrap.Modal('#transaction-modal', {
    keyboard: false,
  });
  document.getElementById('transaction-modal').addEventListener('hidden.bs.modal', function() {
    history.replaceState(null, null, ' ')
  });

  window.onhashchange = function() {
    transactionModal.show();
  };

  if (window.location.hash === '#add') {
    transactionModal.show();
  }

});