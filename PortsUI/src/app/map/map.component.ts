import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
declare var MapmyIndia: any;
declare var L: any;
@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
})
export class MapComponent implements OnInit {
  map: any;
  infoWindow: any;
  now:Date = new Date();
  ngOnInit() {
    this.route.queryParams.subscribe((q) => {
      if (q['lat'] != null) {
        let lat = q['lat'].replace(",", ".");
        let long= q['long'].replace(",", ".");
        var map = new MapmyIndia.Map('map', {
          center: [lat, long],
          zoomControl: false,
          hybrid: false,
        });
        map.invalidateSize();
        L.marker([lat, long]).addTo(map);
        map.setZoom(1);
      }
    });


  }

  constructor(  private router: Router,private route: ActivatedRoute) {}
}
