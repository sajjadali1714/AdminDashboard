function createChart(id, type, heading, label, values, responsive) {
    const ctx = document.getElementById(id);

    new Chart(ctx, {
        type: type,
        data: {
            labels: label,
            datasets: [{
                label: heading,
                data: values,
                borderWidth: 2,
                font: {
                    size: 14,
                    family: "'Poppins', 'monospace','sans-serif'"
                }
            }]
        },
        options: {
            responsive: responsive,
            plugins: {
                legend: {
                    display: true,
                    labels: {
                        font: {
                            size: 14,
                            family: "'Poppins', 'monospace', 'sans-serif'"
                        }
                    }
                }
            },            
            scales: {
                x: {
                    ticks: {
                        font: {
                            size: 14,
                            family: "'Poppins', 'monospace', 'sans-serif'"
                        }
                    },
                },
                y: {
                    ticks: {
                        font: {
                            size: 14,
                            family: "'Poppins', 'monospace', 'sans-serif'"
                        },
                        beginAtZero: true
                    },
                },
                },
                animation:{
                    duration: 3000
                  }            
            
        }
    });
}


function createMultiDataChart(id, type, branches, categories, data, responsive) {
    const ctx = document.getElementById(id).getContext('2d');

    const datasets = branches.map((branch, index) => ({
        label: branch,
        data: data[index],
        borderWidth: 1
    }));

    new Chart(ctx, {
        type: type,
        data: {
            labels: categories,
            datasets: datasets
        },
        options: {
            responsive: responsive,
            plugins: {
                legend: {
                    display: true,
                    labels: {
                        font: {
                            size: 14,
                            family: "'Poppins', 'monospace', 'sans-serif'"
                        }
                    }
                }
            },
            scales: {
                x: {
                    ticks: {
                        font: {
                            size: 14,
                            family: "'Poppins', 'monospace', 'sans-serif'"
                        }
                    }
                },
                y: {
                    ticks: {
                        font: {
                            size: 14,
                            family: "'Poppins', 'monospace', 'sans-serif'"
                        },
                        beginAtZero: true
                    }
                },
            },
            animation: {
                duration: 3000
            }
        }
    });
}



// function createMultiDataChart(id, type, heading, label, values, responsive) {
//     const ctx = document.getElementById(id);

//     new Chart(ctx, {
//         type: type,
//         data: {
//             labels: label,
//             datasets: [{
//                 label: heading[0],
//                 data: values[0],
//                 borderWidth: 1,
//             },
//             {
//                 label: heading[1],
//                 data: values[1],
//                 borderWidth: 1,
//             },
//             {
//                 label: heading[2],
//                 data: values[2],
//                 borderWidth: 1,
//             }]
//         },
//         options: {
//             responsive: responsive,
//             plugins: {
//                 legend: {
//                     display: true,
//                     labels: {
//                         font: {
//                             size: 14,
//                             family: "'Poppins', 'monospace', 'sans-serif'"
//                         }
//                     }
//                 }
//             },
//             scales: {
//                 x: {
//                     ticks: {
//                         font: {
//                             size: 14,
//                             family: "'Poppins', 'monospace', 'sans-serif'"
//                         }
//                     }
//                 },
//                 y: {
//                     ticks: {
//                         font: {
//                             size: 14,
//                             family: "'Poppins', 'monospace', 'sans-serif'"
//                         },
//                         beginAtZero: true
//                     }
//                 },                
//             },
//             animation:{
//                 duration: 3000
//               }
//         }
//     });
// }
