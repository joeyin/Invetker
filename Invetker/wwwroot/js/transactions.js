$(function() {
  var start = moment().subtract(7, 'days');
  var end = moment();
  $('input[name="daterange"]').daterangepicker({
    opens: 'left',
    startDate: start,
    endDate: end,
    maxDate: moment()
  }, function(start, end, label) {
    console.log(start, end, label)
  });
});
