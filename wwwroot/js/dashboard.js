$("#toggle-aside").click(function () {
  $("aside")[0].classList.toggle("collapsed");
});

const chartOptions = {
  credits: {
    enabled: false
  },
  tooltip: {
    enabled: false
  },
  plotOptions: {
    area: {
      fillColor: 'rgba(245, 197, 78, 0.31)',
      marker: {
        enabled: false,
      },
      lineWidth: 2,
      lineColor: 'rgba(245, 197, 79, 0.21)',
      threshold: null,
      states: {
        hover: {
          enabled: false
        }
      }
    },
  },
  title: {
    text: "",
  },
  xAxis: {
    type: "datetime",
    labels: {
      enabled: false
    },
    tickWidth: 0,
    lineWidth: 0,
    minPadding: 0,
    maxPadding: 0
  },
  yAxis: {
    title: {
      text: "",
    },
    labels: {
      enabled: false
    },
    gridLineWidth: 0
  },
  legend: {
    enabled: false
  },
}

const mockData = [
  {
    data: [
      [
        1262304000000,
        0.7537
      ],
      [
        1262563200000,
        0.6951
      ],
      [
        1262649600000,
        0.6925
      ],
      [
        1262736000000,
        0.697
      ],
      [
        1262822400000,
        0.6992
      ],
      [
        1262908800000,
        0.7007
      ],
      [
        1263168000000,
        0.6884
      ],
      [
        1263254400000,
        0.6907
      ],
      [
        1263340800000,
        0.6868
      ],
    ],
  },
];

$(window).ready(function () {
  Highcharts.chart({
    ...chartOptions,
    chart: {
      type: 'area',
      renderTo: document.querySelector("#net-liquidity #chart"),
      backgroundColor: 'transparent',
      margin: [98, 0, 0, 0],
    },
    series: mockData
  });

  Highcharts.chart({
    ...chartOptions,
    chart: {
      type: 'area',
      renderTo: document.querySelector("#portfolio-performance #chart"),
      backgroundColor: 'transparent',
      margin: [98, 0, 0, 0],
    },
    tooltip: {
      enabled: true
    },
    series: mockData
  });
});
