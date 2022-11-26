import { Home } from "./components/Home";
import { Park } from "./components/Park";
import { ParkFilter } from "./components/ParkFilter";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/park',
    element: <Park />
  },
  {
    path: '/parkfilter',
    element: <ParkFilter />
  }
];

export default AppRoutes;
