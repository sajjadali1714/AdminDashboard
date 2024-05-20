// document.addEventListener('DOMContentLoaded', function() {
//     function createChart() {
//       const ctx = document.getElementById('myChart').getContext('2d');
      
//       new Chart(ctx, {
//         type: 'bar',
//         data: {
//           labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
//           datasets: [{
//             label: '# of Votes',
//             data: [12, 19, 3, 5, 2, 3],
//             borderWidth: 1
//           }]
//         },
//         options: {
//           scales: {
//             y: {
//               beginAtZero: true
//             }
//           }
//         }
//       });
//     }
  
//     createChart();
//   });
// var element = document.getElementById("myChart").addEventListener("onLoad", createChart);

function createChart(id,type,heading,label,values,responsive){
const ctx = document.getElementById(id);

  new Chart(ctx, {
    type: type,
    data: {
      labels:  label,
      datasets: [{
        label: heading,
        data: values,
        borderWidth: 1
      }]
    },
    options: {
        plugins: {
            legend: {
                    display: false,                
                labels: {
                    // This more specific font property overrides the global property
                    font: {
                        size: 14
                    }
                }
            }
        },
      scales: {
        x: {
            ticks:{
                display: false
            } ,
            display: false
        },
        y: {
            beginAtZero: true
        }
      }
    }
  });
}