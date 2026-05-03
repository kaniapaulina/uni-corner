export const DepartmentCard = ({ title, code, description }) => (
  <div className="group bg-white border border-gray-100 p-8 rounded-2xl hover:border-agh-red transition-all duration-300 shadow-sm hover:shadow-2xl relative overflow-hidden">
    <div className="absolute top-0 right-0 p-4 font-technical text-gray-100 group-hover:text-agh-red/10 text-6xl font-bold transition-colors">
      {code}
    </div>
    <h3 className="text-xl font-bold mb-4 relative z-10">{title}</h3>
    <p className="text-gray-500 text-sm leading-relaxed mb-6">{description}</p>
    <div className="w-8 h-1 bg-agh-red group-hover:w-full transition-all duration-500" />
  </div>
);